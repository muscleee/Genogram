using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genogram
{
    public partial class Genogram : Form
    {

        // 定義物件
        Graphics g;
        Pen pen, KeyPersonPen, DashStylePen;
        Brush KeyPersonBush;
        Color drawKeyPersonColor = Color.Red;
        Color drawColor = Color.Black;
        bool isMouseDown;
        string DrawType;
        List<Point> points = new List<Point>();
        SelfInfo selfInfo;
        ChildInfo childInfo;
        ParentInfo parentInfo;
        SlashLine slashLine;
        float DrawPanelWidth, DrawPanelHeight, ShapeWidth, ShapeHeight;
        float lineDropY, lineWidth;
        float selfShapeRatio_y, childShapeRatio_y, parentShapeRatio_y, selfShapeRatio_M_x, selfShapeRatio_W_x;
        float otherShapeRatio_W_x, otherShapeRatio_M_x, otherShapeDistanceRatio, twoShapeDistanceRatio;
        float selfShapeDistanceRatio;
        float childInitialRatio_x;
        float slashWidth, slashHeight;

        public Genogram()
        {
            InitializeComponent();
            iniControlInfo();
            DrawShapeComponent();

            iniInfo();
        }

        public void iniInfo()
        {
            selfInfo = new SelfInfo();
            childInfo = new ChildInfo();
            parentInfo = new ParentInfo();
            slashLine = new SlashLine();

        }
        public void iniControlInfo()
        {
            ShapeSize_textBox.Text = "50";
            man_radioButton.Checked = true;
            self_relation_parent_radioButton.Checked = true;
            self_married_radioButton.Checked = true;
            paternal_married_radioButton.Checked = true;
            maternal_married_radioButton.Checked = true;
        }

        public void DrawShapeComponent()
        {
            lineWidth = 3;
            g = DrawPanel.CreateGraphics();
            // 一般畫筆
            pen = new Pen(drawColor, lineWidth);
            // 個案畫筆
            KeyPersonPen = new Pen(drawKeyPersonColor, lineWidth);
            // 虛線畫筆
            DashStylePen = new Pen(drawColor, lineWidth);
            //DashStylePen.DashStyle = DashStyle.Custom;
            DashStylePen.DashPattern = new float[] { 1f, 1f };

            KeyPersonBush = new SolidBrush(Color.Gray);

            // 畫布長寬
            DrawPanelWidth = DrawPanel.Width;
            DrawPanelHeight = DrawPanel.Height;
            // 所建圖形大小
            ShapeWidth = ShapeHeight = Convert.ToSingle(ShapeSize_textBox.Text);
            // 男女連線下降高度
            lineDropY = ShapeWidth / 2;
            // 離婚等斜線寬高度 (與中心點相距)
            slashWidth = slashHeight = 10;
            // 不同類別的高度
            parentShapeRatio_y = 0.1f;
            selfShapeRatio_y = 0.4f;
            childShapeRatio_y = 0.7f;
            // 個案男女位置初始(畫布比例，形狀左上角起點)
            selfShapeRatio_M_x = 0.4f;
            selfShapeRatio_W_x = 0.6f;
            otherShapeRatio_M_x = 0.45f;
            otherShapeRatio_W_x = 0.55f;
            selfShapeDistanceRatio = selfShapeRatio_W_x - selfShapeRatio_M_x;
            otherShapeDistanceRatio = otherShapeRatio_W_x - otherShapeRatio_M_x;
            twoShapeDistanceRatio = selfShapeDistanceRatio / otherShapeDistanceRatio;

        }

        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            if (points.Count != 0)
            {
                Point lastPoint, currentPoint;
                Point breakpoint = new Point(-1, -1);
                for (int idx = 0; idx < points.Count - 1; idx++)
                {
                    lastPoint = points[idx];
                    currentPoint = points[idx + 1];
                    if (DrawType == "Draw" && lastPoint != breakpoint && currentPoint != breakpoint)
                    {
                        g.DrawLine(pen, lastPoint, currentPoint);
                    }
                }
            }

        }

        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            points.Add(e.Location);

            if (DrawType == "Clear")
            {
                points = new List<Point>();
                g.Clear(Color.White);

            }
        }

        private void DrawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            points.Add(new Point(-1, -1));
        }

        private void DrawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (DrawType == "Draw" && isMouseDown)
            {
                points.Add(e.Location);
                g.DrawLine(pen, points[points.Count - 2], points[points.Count - 1]);
            }
        }

        // ===== 子女狀況
        // 男女
        private void addChild_Boy_button_Click(object sender, EventArgs e)
        {
            child_textBox.Text = child_textBox.Text + " 男";
        }

        private void addChild_Girl_button_Click(object sender, EventArgs e)
        {
            child_textBox.Text = child_textBox.Text + " 女";
        }
        // 婚姻
        private void addChild_unmarried_button_Click(object sender, EventArgs e)
        {
            child_marriage_textBox.Text = child_marriage_textBox.Text + " 未";
        }
        private void addChild_married_button_Click(object sender, EventArgs e)
        {
            child_marriage_textBox.Text = child_marriage_textBox.Text + " 結";
        }

        private void addChild_cohabit_button_Click(object sender, EventArgs e)
        {
            child_marriage_textBox.Text = child_marriage_textBox.Text + " 同";
        }

        private void addChild_separate_button_Click(object sender, EventArgs e)
        {
            child_marriage_textBox.Text = child_marriage_textBox.Text + " 分";
        }

        private void addChild_divorce_button_Click(object sender, EventArgs e)
        {
            child_marriage_textBox.Text = child_marriage_textBox.Text + " 離";
        }



        // 子女狀況 [End]

        // ===== 畫布功能
        private void Drag_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Drag_radioButton.Checked) DrawType = "Drag";
        }

        private void ShapeSize_textBox_TextChanged(object sender, EventArgs e)
        {
            ShapeWidth = ShapeHeight = Convert.ToSingle(ShapeSize_textBox.Text);
        }


        private void self_relation_parent_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (self_relation_parent_radioButton.Checked)
            {
                self_unmarried_radioButton.Checked = false;
                self_unmarried_radioButton.Enabled = false;
                selfShapeRatio_y = 0.4f;
                selfShapeRatio_M_x = 0.4f;
                selfShapeRatio_W_x = 0.6f;
                selfShapeDistanceRatio = selfShapeRatio_W_x - selfShapeRatio_M_x;

                paternal_marriage_label.Text = "男方長輩婚姻 : ";
                maternal_marriage_label.Visible = true;
                maternal_marriage_panel.Visible = true;

                if (!(self_married_radioButton.Checked || self_cohabit_radioButton.Checked ||
                      self_separate_radioButton.Checked || self_divorce_radioButton.Checked)) self_married_radioButton.Checked = true;

                // 測試用
                if (child_textBox.Text == "") child_textBox.Text = "男 女";

            }
            else
            {
                self_unmarried_radioButton.Enabled = true;
                // 測試用
                child_textBox.Text = "";
            }
        }

        private void self_relation_childern_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (self_relation_childern_radioButton.Checked)
            {
                selfShapeRatio_y = 0.6f;
                selfShapeRatio_M_x = 0.45f;
                selfShapeRatio_W_x = 0.55f;
                selfShapeDistanceRatio = selfShapeRatio_W_x - selfShapeRatio_M_x;

                paternal_marriage_label.Text = "　　爸媽婚姻 : ";
                maternal_marriage_label.Visible = false;
                maternal_marriage_panel.Visible = false;
            }
        }

        private void Draw_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Draw_radioButton.Checked) DrawType = "Draw";
        }

        private void Clear_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Clear_radioButton.Checked) DrawType = "Clear";
        }
        // 畫布功能 [End]

        private void execute_button_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            calculateInfo();

            //g.DrawEllipse(pen, 3000, 500, 100, 100);
        }

        private List<float> DrawParent(float x1, float y, float ShapeDistanceRatio)
        {
            // x : 孩子圖形中心點x座標, y : 孩子圖形左上y座標, ShapeDistanceRatio : 男女距離，決定連接長度
            float m_parentLineX1, m_parentLineY1, m_parentLineX2, m_parentLineY2;
            float m_fatherXpos, m_fatherYpos, m_motherXpos, m_motherYpos;
            List<float> position = new List<float> { };
            // 父母(男)
            m_parentLineX1 = x1 - DrawPanelWidth* ShapeDistanceRatio / 2;
            m_parentLineX2 = x1 + DrawPanelWidth* ShapeDistanceRatio / 2;
            m_parentLineY1 = y - lineDropY* 2;
            m_parentLineY2 = y - lineDropY;
            m_fatherXpos = m_parentLineX1 - ShapeWidth / 2;
            m_motherXpos = m_parentLineX2 - ShapeWidth / 2;
            m_fatherYpos = m_motherYpos = m_parentLineY1 - ShapeHeight;

            ConnectShape(pen, "bottom", m_parentLineX1, m_parentLineY1, m_parentLineX2, m_parentLineY2);
            // 連接子女垂直線
            slashLine = getSlashXY(slashLine, "vertical", m_parentLineX1, m_parentLineY1, m_parentLineX2, m_parentLineY2);
            g.DrawRectangle(pen, m_fatherXpos, m_fatherYpos, ShapeWidth, ShapeHeight);
            g.DrawEllipse(pen, m_motherXpos, m_motherYpos, ShapeWidth, ShapeHeight);
            position.Add(m_fatherXpos); position.Add(m_motherXpos); position.Add(m_fatherYpos);
            return position;
        }

        // ===== 圖像計算
        private void calculateInfo()
        {
            float selfManXpos, selfManYpos, selfWomanXpos, selfWomanYpos;
            float selfPersonLineY1, selfPersonLineY2, selfPersonLineX1, selfPersonLineX2;
            float childLineX1, childLineY1, childLineX2, childLineY2;
            //float m_parentLineX1, m_parentLineY1, m_parentLineX2, m_parentLineY2;
            //float m_fatherXpos, m_fatherYpos, m_motherXpos, m_motherYpos;
            //float w_parentLineX1, w_parentLineY1, w_parentLineX2, w_parentLineY2;
            //float w_fatherXpos, w_fatherYpos, w_motherXpos, w_motherYpos;
            List<float> grandparent_Pos;
            float childYpos;
            // 個案男女的x, y
            selfManXpos = selfShapeRatio_M_x * DrawPanelWidth;
            selfWomanXpos = selfShapeRatio_W_x * DrawPanelWidth;
            selfManYpos = selfWomanYpos = selfShapeRatio_y * DrawPanelHeight;
            // 個案男女連線x, y
            selfPersonLineX1 = selfManXpos + ShapeWidth / 2;
            selfPersonLineX2 = selfWomanXpos + ShapeWidth / 2;
            selfPersonLineY1 = selfManYpos + ShapeHeight + lineWidth / 2; // 校正線寬造成的重疊區 (lineWidth/2)
            selfPersonLineY2 = selfPersonLineY1 + lineDropY;
            // 個案男女連線狀態(反斜線, 叉叉) x, y
            //slashX1 = (selfPersonLineX1 + selfPersonLineX2) / 2 - slashWidth;
            //slashY1 = selfPersonLineY2 - slashHeight;
            //slashX2 = (selfPersonLineX1 + selfPersonLineX2) / 2 + slashWidth;
            //slashY2 = selfPersonLineY2 + slashHeight;

            // 子女
            childLineX1 = selfPersonLineX1;
            childLineX2 = selfPersonLineX2;
            childLineY1 = selfPersonLineY2 + lineDropY;
            childLineY2 = childLineY1 + lineDropY;
            childYpos = childShapeRatio_y * DrawPanelHeight;

            //// 父母(男)
            //m_parentLineX1 = selfPersonLineX1 - DrawPanelWidth * otherShapeDistanceRatio / 2;
            //m_parentLineX2 = selfPersonLineX1 + DrawPanelWidth * otherShapeDistanceRatio / 2;
            //m_parentLineY1 = selfManYpos - lineDropY * 2;
            //m_parentLineY2 = selfManYpos - lineDropY;
            //m_fatherXpos = m_parentLineX1 - ShapeWidth / 2;
            //m_motherXpos = m_parentLineX2 - ShapeWidth / 2;
            //m_fatherYpos = m_motherYpos = m_parentLineY1 - ShapeHeight / 2 - lineDropY;
            //// 父母(女)
            //w_parentLineX1 = selfPersonLineX2 - DrawPanelWidth * otherShapeDistanceRatio / 2;
            //w_parentLineX2 = selfPersonLineX2 + DrawPanelWidth * otherShapeDistanceRatio / 2;
            //w_parentLineY1 = selfManYpos - lineDropY * 2;
            //w_parentLineY2 = selfManYpos - lineDropY;
            //w_fatherXpos = w_parentLineX1 - ShapeWidth / 2;
            //w_motherXpos = w_parentLineX2 - ShapeWidth / 2;
            //w_fatherYpos = w_motherYpos = m_parentLineY1 - ShapeHeight / 2 - lineDropY;


            // [個案圖形]
            if (man_radioButton.Checked)
            {
                selfInfo.member += 1;
                g.FillRectangle(KeyPersonBush, selfManXpos, selfManYpos, ShapeWidth, ShapeHeight);
                g.DrawRectangle(pen, selfManXpos, selfManYpos, ShapeWidth, ShapeHeight);
                if (!self_unmarried_radioButton.Checked)
                {
                    g.DrawEllipse(pen, selfWomanXpos, selfWomanYpos, ShapeWidth, ShapeHeight);
                }

            }

            if (woman_radioButton.Checked)
            {
                selfInfo.member += 1;
                g.FillEllipse(KeyPersonBush, selfWomanXpos, selfWomanYpos, ShapeWidth, ShapeHeight);
                g.DrawEllipse(pen, selfWomanXpos, selfWomanYpos, ShapeWidth, ShapeHeight);
                if (!self_unmarried_radioButton.Checked)
                {
                    g.DrawRectangle(pen, selfManXpos, selfManYpos, ShapeWidth, ShapeHeight);
                }
            }

            // [個案婚姻連線]
            // 結婚
            if (self_married_radioButton.Checked)
            {
                ConnectShape(pen, "bottom", selfPersonLineX1, selfPersonLineY1, selfPersonLineX2, selfPersonLineY2);
            }
            // 同居
            else if (self_cohabit_radioButton.Checked)
            {
                ConnectShape(DashStylePen, "bottom", selfPersonLineX1, selfPersonLineY1, selfPersonLineX2, selfPersonLineY2);
            }
            // 分居
            else if (self_separate_radioButton.Checked)
            {
                ConnectShape(pen, "bottom", selfPersonLineX1, selfPersonLineY1, selfPersonLineX2, selfPersonLineY2);
                slashLine = getSlashXY(slashLine, "backslash", selfPersonLineX1, selfPersonLineY1, selfPersonLineX2, selfPersonLineY2);
            }
            // 離婚
            else if (self_divorce_radioButton.Checked)
            {
                ConnectShape(pen, "bottom", selfPersonLineX1, selfPersonLineY1, selfPersonLineX2, selfPersonLineY2);
                slashLine = getSlashXY(slashLine, "backslash", selfPersonLineX1, selfPersonLineY1, selfPersonLineX2, selfPersonLineY2);
                slashLine = getSlashXY(slashLine, "slash", selfPersonLineX1, selfPersonLineY1, selfPersonLineX2, selfPersonLineY2);
            }

            // [個案爸媽圖形]
            //// 爸
            //if (self_relation_parent_radioButton.Checked || man_radioButton.Checked)
            //{
            //    ConnectShape(pen, "bottom", m_parentLineX1, m_parentLineY1, m_parentLineX2, m_parentLineY2);
            //    // 連接子女垂直線
            //    slashLine = getSlashXY(slashLine, "vertical", m_parentLineX1, m_parentLineY1, m_parentLineX2, m_parentLineY2);
            //    g.DrawRectangle(pen, m_fatherXpos, m_fatherYpos, ShapeWidth, ShapeHeight);
            //    g.DrawEllipse(pen, m_motherXpos, m_motherYpos, ShapeWidth, ShapeHeight);
            //}
            //// 媽
            //if (self_relation_parent_radioButton.Checked || woman_radioButton.Checked)
            //{
            //    ConnectShape(pen, "bottom", w_parentLineX1, w_parentLineY1, w_parentLineX2, w_parentLineY2);
            //    // 連接子女垂直線
            //    slashLine = getSlashXY(slashLine, "vertical", w_parentLineX1, w_parentLineY1, w_parentLineX2, w_parentLineY2);
            //    g.DrawRectangle(pen, w_fatherXpos, w_fatherYpos, ShapeWidth, ShapeHeight);
            //    g.DrawEllipse(pen, w_motherXpos, w_motherYpos, ShapeWidth, ShapeHeight);
            //}

            //if (self_relation_parent_radioButton.Checked || man_radioButton.Checked) DrawParent(selfPersonLineX1, selfManYpos);
            //if (self_relation_parent_radioButton.Checked || woman_radioButton.Checked) DrawParent(selfPersonLineX2, selfManYpos);
            if (self_relation_parent_radioButton.Checked)
            {
                DrawParent(selfPersonLineX1, selfManYpos, otherShapeDistanceRatio); // 男方
                DrawParent(selfPersonLineX2, selfManYpos, otherShapeDistanceRatio); // 女方
            }
            else if (man_radioButton.Checked)
            {
                grandparent_Pos = DrawParent(selfPersonLineX1, selfManYpos, otherShapeDistanceRatio*2);
                DrawParent(grandparent_Pos[0] + ShapeWidth / 2, grandparent_Pos[2], otherShapeDistanceRatio);
                DrawParent(grandparent_Pos[1] + ShapeWidth / 2, grandparent_Pos[2], otherShapeDistanceRatio);
            }
            else if (woman_radioButton.Checked)
            {
                grandparent_Pos = DrawParent(selfPersonLineX2, selfManYpos, otherShapeDistanceRatio * 2);
                DrawParent(grandparent_Pos[0] + ShapeWidth / 2, grandparent_Pos[2], otherShapeDistanceRatio);
                DrawParent(grandparent_Pos[1] + ShapeWidth / 2, grandparent_Pos[2], otherShapeDistanceRatio);
            }


            // [子女圖形]
            // 從TextBox獲取數量
            getChildNum();

            string[] childMarriage = child_marriage_textBox.Text.Trim().Split(' ');            
            childInfo.marriage = childMarriage.Where(item => item == "未" || item == "結" || item == "同" || item == "分" || item == "離").ToList();
            childInfo.marriageType = childMarriage.Where(item => item == "結" || item == "同" || item == "分" || item == "離").ToList();
            childInfo.childmarriageNum = childInfo.marriageType.Count();
            int marriageCount = childInfo.marriage.Count();
            for (int i = 0; i < childInfo.totalNumber - marriageCount; i++)
            {
                childInfo.marriage.Add("未");
            }

            // 子女數量>0才需畫圖
            if (childInfo.totalNumber > 0)
            {
                // 連接子女垂直線
                slashLine = getSlashXY(slashLine, "vertical", selfPersonLineX1, selfPersonLineY1, selfPersonLineX2, selfPersonLineY2);

                // 設定起始位置。 奇數子女數量
                int childAddMarriageNum = childInfo.totalNumber + childInfo.childmarriageNum;
                if (Convert.ToBoolean(childAddMarriageNum % 2))
                {
                    // selfShapeRatio_M_x 先減個案男女距離的一半
                    if (childInfo.totalNumber == 1)
                    {
                        childInitialRatio_x = selfShapeRatio_M_x + selfShapeDistanceRatio / 2;
                    }
                    else
                    {
                        if (childInfo.marriage.Count()==2 && childInfo.marriage[0] == "未")
                        {
                            childInitialRatio_x = selfShapeRatio_M_x + selfShapeDistanceRatio / 2 - otherShapeDistanceRatio / 2 - (childAddMarriageNum / 2 - 1) * otherShapeDistanceRatio;
                        }
                        else
                        {
                            childInitialRatio_x = selfShapeRatio_M_x + selfShapeDistanceRatio / 2 - (childAddMarriageNum / 2) * otherShapeDistanceRatio;
                        }
                        
                    }
                }
                // 偶數子女數量
                else
                {
                    if (childInfo.totalNumber == 1)
                    {
                        childInitialRatio_x = selfShapeRatio_M_x + selfShapeDistanceRatio / 2;
                    }
                    else
                    {
                        // selfShapeRatio_M_x + selfShapeDistanceRatio/2 → 移到男女正中間 → - otherShapeDistanceRatio / 2 → 往前校正到偶數初始位置 →  - (childAddMarriageNum / 2 - 1) * otherShapeDistanceRatio → 剩下的正常加上距離 
                        childInitialRatio_x = selfShapeRatio_M_x + selfShapeDistanceRatio/2 - otherShapeDistanceRatio / 2 - (childAddMarriageNum / 2 - 1) * otherShapeDistanceRatio;
                    }
                    
                }

                float Ratio_x = childInitialRatio_x;
                float Xpos, Ypos;
                childInfo.Xpos = new List<float> { };
                childInfo.Xpos_marriage = new List<float> { };
                // 只有1個小孩時，初始高度不一樣
                childInfo.Ypos = childInfo.member.Count() == 1 ? childLineY1 : childLineY2;
                childInfo.Ypos_marriage = childInfo.Ypos + ShapeWidth;
                int index = 0;
                foreach (string item in childInfo.member)
                {
                    
                    Xpos = Ratio_x * DrawPanelWidth;
                    if (item == "男")
                    {
                        g.DrawRectangle(pen, Xpos, childInfo.Ypos, ShapeWidth, ShapeHeight);

                    }
                    else if (item == "女")
                    {
                        g.DrawEllipse(pen, Xpos, childInfo.Ypos, ShapeWidth, ShapeHeight);

                    }
                    // 把位置記錄在childInfo，方便連線使用
                    childInfo.Xpos.Add(Xpos + ShapeWidth / 2); //中心點x

                    Ratio_x = Ratio_x + 0.1f;

                    // 處理該子女婚姻狀態，當不是未結婚時，生成相對圖形，並記錄前面點的位置，方便後續婚姻連線
                    if (childInfo.marriage[index] != "未")
                    {
                        // 紀錄前面點的位置
                        childInfo.Xpos_marriage.Add(Xpos + ShapeWidth / 2); //中心點x

                        // 新的初始點，生成伴侶的圖形(與原性別對應的圖形)
                        Xpos = Ratio_x * DrawPanelWidth;
                        if (item == "男")
                        {
                            g.DrawEllipse(pen, Xpos, childInfo.Ypos, ShapeWidth, ShapeHeight);
                        }
                        else if (item == "女")
                        {
                            g.DrawRectangle(pen, Xpos, childInfo.Ypos, ShapeWidth, ShapeHeight);                           
                        }
                        // 紀錄伴侶的圖形的初始位置
                        childInfo.Xpos_marriage.Add(Xpos + ShapeWidth / 2); //中心點x
                        Ratio_x = Ratio_x + 0.1f;

                    }
                    index += 1;
                }

                for (int idx = 0; idx < childInfo.Xpos.Count() - 1; idx++)
                {
                    //前後兩兩連線
                    ConnectShape(pen, "top", childInfo.Xpos[idx], childLineY1, childInfo.Xpos[idx + 1], childInfo.Ypos);
                }

                // 處理子女婚姻的連線狀態
                for (int i = 0; i < childInfo.childmarriageNum; i++)
                {
                    int idx = i * 2;
                    string item = childInfo.marriageType[i];
                    if (item == "結")
                    {
                        ConnectShape(pen, "bottom", childInfo.Xpos_marriage[idx], childInfo.Ypos_marriage, childInfo.Xpos_marriage[idx + 1], childInfo.Ypos_marriage + lineDropY);
                    }
                    // 同居
                    else if (item == "同")
                    {
                        ConnectShape(DashStylePen, "bottom", childInfo.Xpos_marriage[idx], childInfo.Ypos_marriage, childInfo.Xpos_marriage[idx + 1], childInfo.Ypos_marriage + lineDropY);
                    }
                    // 分居
                    else if (item == "分")
                    {
                        ConnectShape(pen, "bottom", childInfo.Xpos_marriage[idx], childInfo.Ypos_marriage, childInfo.Xpos_marriage[idx + 1], childInfo.Ypos_marriage + lineDropY);
                        slashLine = getSlashXY(slashLine, "backslash", childInfo.Xpos_marriage[idx], childInfo.Ypos_marriage, childInfo.Xpos_marriage[idx + 1], childInfo.Ypos_marriage + lineDropY);
                    }
                    // 離婚
                    else if (item == "離")
                    {
                        ConnectShape(pen, "bottom", childInfo.Xpos_marriage[idx], childInfo.Ypos_marriage, childInfo.Xpos_marriage[idx + 1], childInfo.Ypos_marriage + lineDropY);
                        slashLine = getSlashXY(slashLine, "backslash", childInfo.Xpos_marriage[idx], childInfo.Ypos_marriage, childInfo.Xpos_marriage[idx + 1], childInfo.Ypos_marriage + lineDropY);
                        slashLine = getSlashXY(slashLine, "slash", childInfo.Xpos_marriage[idx], childInfo.Ypos_marriage, childInfo.Xpos_marriage[idx + 1], childInfo.Ypos_marriage + lineDropY);
                    }
                }

            }

        }
        // 圖像計算 [End]

        
        // 圖形連結形狀
        private void ConnectShape(Pen drawPen, string type, float x1, float y1, float x2, float y2)
        {
            // 左垂直線
            g.DrawLine(drawPen, x1, y1, x1, y2);
            // 右垂直線
            g.DrawLine(drawPen, x2, y1, x2, y2);
            // 水平線
            float HorizontalLineY = type == "top" ? y1 : y2;           
            g.DrawLine(drawPen, x1 - lineWidth / 2, HorizontalLineY, x2 + lineWidth / 2, HorizontalLineY);

        }

        private SlashLine getSlashXY(SlashLine LineInfo, string type, float x1, float y1, float x2, float y2)
        {
            if (type == "slash")
            {
                // 斜線
                LineInfo.x1 = (x1 + x2) / 2 - slashWidth;
                LineInfo.y1 = y2 + slashHeight;
                LineInfo.x2 = (x1 + x2) / 2 + slashWidth;
                LineInfo.y2 = y2 - slashHeight;           
            }
            else if (type == "backslash")
            {
                // 反斜線
                LineInfo.x1 = (x1 + x2) / 2 - slashWidth;
                LineInfo.y1 = y2 - slashHeight;
                LineInfo.x2 = (x1 + x2) / 2 + slashWidth;
                LineInfo.y2 = y2 + slashHeight;
            }
            else if (type == "vertical")
            {
                // 垂直線
                LineInfo.x1 = (x1 + x2) / 2;
                LineInfo.y1 = y2;
                LineInfo.x2 = (x1 + x2) / 2;
                LineInfo.y2 = y2 + lineDropY;
            }
            g.DrawLine(pen, LineInfo.x1, LineInfo.y1, LineInfo.x2, LineInfo.y2);

            return LineInfo;
        }

        private void getChildNum()
        {
            string childString = child_textBox.Text.Trim();
            string[] childStrVec = childString.Split(' ');
            childInfo.member = childStrVec.Where(item => item == "男" || item == "女").ToList();
            // 重置子女數量
            childInfo.boyNumber = childInfo.girlNumber = 0;
            foreach (string item in childInfo.member)
            {
                if (item == "男")
                {
                    childInfo.boyNumber = childInfo.boyNumber + 1;
                }
                else if (item == "女")
                {
                    childInfo.girlNumber = childInfo.girlNumber + 1;
                }
            }
            childInfo.totalNumber = childInfo.boyNumber + childInfo.girlNumber;
        }

        struct SelfInfo
        {
            public int member;
            public string marriage;
        }

        struct ChildInfo
        {
            public List<string> member;
            public List<string> marriage;
            public List<string> marriageType;
            public int boyNumber, girlNumber, totalNumber;
            public List<float> Xpos;
            public float Ypos;
            public List<float> Xpos_marriage;
            public float Ypos_marriage;
            public int childmarriageNum;
        }

        struct ParentInfo
        {
            public int member;
            public string marriage;
        }

        struct SlashLine
        {
            public float x1;
            public float y1;
            public float x2;
            public float y2;
        }

    }
}
