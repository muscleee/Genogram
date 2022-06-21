﻿using System;
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
        Brush testPersonBush;
        Color drawKeyPersonColor = Color.Red;
        Color drawColor = Color.Black;
        Font font;
        bool isMouseDown;
        string DrawType;
        List<Point> points = new List<Point>();
        SelfInfo selfInfo;
        ChildInfo childInfo;
        ParentInfo parentInfo;
        GrandParentInfo grandparentInfo;
        SlashLine slashLine;
        ShapeInfo shapeInfo;
        float DrawPanelWidth, DrawPanelHeight, ShapeWidth, ShapeHeight;
        float lineDropY, lineWidth;
        float selfShapeRatio_y, childShapeRatio_y, parentShapeRatio_y, selfShapeRatio_M_x, selfShapeRatio_W_x;
        float otherShapeRatio_W_x, otherShapeRatio_M_x, otherShapeDistanceRatio, twoShapeDistanceRatio;
        float lineX1, lineY1, lineX2, lineY2;
        float selfShapeDistanceRatio;
        float childInitialRatio_x;
        float slashWidth, slashHeight;
        MovePoint originalPoint;
        Rectangle rect, rect2, tmpRect;
        List<Rectangle> rects = new List<Rectangle>();
        List<RectangleF> RecordAllRectF = new List<RectangleF>();
        List<ShapeInfo> findShapeInfo = new List<ShapeInfo>();
        List<ShapeInfo> RecordShapeInfo = new List<ShapeInfo>();

        public Genogram()
        {
            InitializeComponent();
            IniControlInfo();
            DrawShapeComponent();

            IniInfo();
        }

        public void IniInfo()
        {
            selfInfo = new SelfInfo();
            childInfo = new ChildInfo();
            parentInfo = new ParentInfo();
            grandparentInfo = new GrandParentInfo();
            slashLine = new SlashLine();
            shapeInfo = new ShapeInfo();

            originalPoint = new MovePoint();
            rect = new Rectangle(200, 200, 50, 50);
            rect2 = new Rectangle(400, 400, 50, 50);
            rects.Add(rect); rects.Add(rect2);

        }
        public void IniControlInfo()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            ShapeSize_textBox.Text = "50";
            //Drag_radioButton.Checked = true;
            man_radioButton.Checked = true;
            self_relation_parent_radioButton.Checked = true;
            self_married_radioButton.Checked = true;
            paternal_married_radioButton.Checked = true;
            maternal_married_radioButton.Checked = true;
            parent_married_radioButton.Checked = true;
        }




        public void DrawShapeComponent()
        {
            lineWidth = 3;
            //g = DrawPanel.CreateGraphics();
            g = Graphics.FromHwnd(DrawPanel.Handle);
            // 一般畫筆
            pen = new Pen(drawColor, lineWidth);
            // 個案畫筆
            KeyPersonPen = new Pen(drawKeyPersonColor, lineWidth);
            // 虛線畫筆
            DashStylePen = new Pen(drawColor, lineWidth);
            //DashStylePen.DashStyle = DashStyle.Custom;
            DashStylePen.DashPattern = new float[] { 1f, 1f };
            // 個案顏色
            KeyPersonBush = new SolidBrush(Color.Gray);
            testPersonBush = new SolidBrush(Color.Red);

            font = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel);

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
            //foreach (var item in rects)
            //{
            //    g.DrawRectangle(pen, item);
            //}
            
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
            //CalculateInfo();
            //if (findShapeInfo.Count > 0)
            //{
            //    if (findShapeInfo[0].gender == "男")
            //    {
            //        g.FillRectangle(testPersonBush, findShapeInfo[0].x1, findShapeInfo[0].y1, ShapeWidth, ShapeHeight);
            //        g.DrawRectangle(pen, findShapeInfo[0].x1, findShapeInfo[0].y1, ShapeWidth, ShapeHeight);
            //        e.Graphics.DrawString(age_textBox.Text, font, Brushes.Black, findShapeInfo[0].x1 + ShapeWidth * 0.3f, findShapeInfo[0].y1 + ShapeHeight * 0.3f);
            //    }
            //    else if (findShapeInfo[0].gender == "女")
            //    {
            //        g.FillEllipse(testPersonBush, findShapeInfo[0].x1, findShapeInfo[0].y1, ShapeWidth, ShapeHeight);
            //        g.DrawEllipse(pen, findShapeInfo[0].x1, findShapeInfo[0].y1, ShapeWidth, ShapeHeight);
            //        e.Graphics.DrawString(age_textBox.Text, font, Brushes.Black, findShapeInfo[0].x1 + ShapeWidth * 0.3f, findShapeInfo[0].y1 + ShapeHeight * 0.3f);
            //    }
            //}

            //g.Clear(Color.White);
            foreach (var item in RecordShapeInfo)
            {
                if (item.gender == "男")
                {
                    if (item.status == "KeyPerson")
                    {
                        g.FillRectangle(KeyPersonBush, item.x1, item.y1, ShapeWidth, ShapeHeight);
                    }
                    g.DrawRectangle(pen, item.x1, item.y1, ShapeWidth, ShapeHeight);
                    e.Graphics.DrawString(item.age, font, Brushes.Black, item.x1 + ShapeWidth/2 - 7.5f* item.age.Count(), item.y1 + ShapeHeight/2 - 12);
                }
                else if (item.gender == "女")
                {
                    if (item.status == "KeyPerson")
                    {
                        g.FillEllipse(KeyPersonBush, item.x1, item.y1, ShapeWidth, ShapeHeight);
                    }
                    g.DrawEllipse(pen, item.x1, item.y1, ShapeWidth, ShapeHeight);
                    e.Graphics.DrawString(item.age, font, Brushes.Black, item.x1 + ShapeWidth / 2 - 7.5f * item.age.Count(), item.y1 + ShapeHeight / 2 - 12);
                }
                else if (item.status == "bottom")
                {
                    ConnectShape(item.pen, "bottom", item.x1, item.y1, item.x2, item.y2);
                }
                else if (item.status == "top")
                {
                    ConnectShape(item.pen, "top", item.x1, item.y1, item.x2, item.y2);
                }
                else if (item.status == "backslash")
                {
                    slashLine = getSlashXY(slashLine, "backslash", item.x1, item.y1, item.x2, item.y2);
                }
                else if (item.status == "slash")
                {
                    slashLine = getSlashXY(slashLine, "slash", item.x1, item.y1, item.x2, item.y2);
                }
                else if (item.status == "vertical")
                {
                    slashLine = getSlashXY(slashLine, "vertical", item.x1, item.y1, item.x2, item.y2);
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

            originalPoint.X = e.X;
            originalPoint.Y = e.Y;

            findShapeInfo = RecordShapeInfo.Where(item => item.x1-5 < e.X && e.X < item.x2+5 &&
                                                          item.y1-5 < e.Y && e.Y < item.y2+5).ToList();

            if (findShapeInfo.Count > 0)
            {
                age_textBox.Text = findShapeInfo[0].age != "" ? findShapeInfo[0].age : "";

                switch (findShapeInfo[0].status)
                {
                    case "KeyPerson":
                    case "Parent":
                    case "Paternal GrandParent":
                    case "Maternal GrandParent":
                    case "":
                        age_textBox.Focus();
                        break;
                    case "top":
                    case "bottom":
                        status_comboBox.Items.Clear();
                        status_comboBox.Focus();
                        status_comboBox.Text = findShapeInfo[0].status;
                        status_comboBox.Items.Add("top");
                        status_comboBox.Items.Add("bottom");
                        break;
                    case "slash":
                    case "backslash":                    
                    case "vertical":
                        status_comboBox.Items.Clear();
                        status_comboBox.Focus();
                        status_comboBox.Text = findShapeInfo[0].status;
                        status_comboBox.Items.Add("slash");
                        status_comboBox.Items.Add("backslash");
                        status_comboBox.Items.Add("vertical");
                        break;
                }

               
                //age_textBox.Text = "";


                //    // 紀錄舊資訊
                //    shapeInfo.index = findShapeInfo[0].index;
                //    shapeInfo.age = findShapeInfo[0].age;
                //    shapeInfo.disease = findShapeInfo[0].disease; // 疾病
                //    shapeInfo.status = findShapeInfo[0].status; // 身分地位
                //    shapeInfo.gender = findShapeInfo[0].gender; //性別
                //    //shapeInfo.gender = "男女";
                //    shapeInfo.x1 = findShapeInfo[0].x1; shapeInfo.y1 = findShapeInfo[0].y1;
                //    findShapeInfo.Remove(findShapeInfo[0]);
                //    findShapeInfo.Add(shapeInfo);



                //    originalPoint = new MovePoint { X = e.X, Y = e.Y };
                //    this.Invalidate(true);
            }
            

        }

        private void age_textBox_TextChanged(object sender, EventArgs e)
        {
            findShapeInfo = RecordShapeInfo.Where(item => item.x1 < originalPoint.X && originalPoint.X < item.x1 + ShapeWidth &&
                                                          item.y1 < originalPoint.Y && originalPoint.Y < item.y1 + ShapeHeight).ToList();
            if (findShapeInfo.Count > 0)
            {
                foreach (var item in findShapeInfo)
                {
                    RecordShapeInfo.Remove(item);
                }

                // 暫存 ShapeInfo
                ShapeInfo tmpshapeInfo;
                tmpshapeInfo = findShapeInfo[0];
                //int index = RecordShapeInfo.IndexOf(tmpshapeInfo);
                // 移除找到的 ShapeInfo
                //RecordShapeInfo.Remove(tmpshapeInfo);
                tmpshapeInfo.age = age_textBox.Text;
                // 新增更新的 ShapeInfo
                RecordShapeInfo.Add(tmpshapeInfo);

                this.Invalidate(true);
            }
        }

        private void status_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            findShapeInfo = RecordShapeInfo.Where(item => item.x1 < originalPoint.X && originalPoint.X < item.x1 + ShapeWidth &&
                                                          item.y1 < originalPoint.Y && originalPoint.Y < item.y1 + ShapeHeight).ToList();
            if (findShapeInfo.Count > 0)
            {
                foreach (var item in findShapeInfo)
                {
                    RecordShapeInfo.Remove(item);
                }

                // 暫存 ShapeInfo
                ShapeInfo tmpshapeInfo;
                tmpshapeInfo = findShapeInfo[0];
                tmpshapeInfo.status = status_comboBox.Text;
                // 新增更新的 ShapeInfo
                RecordShapeInfo.Add(tmpshapeInfo);

                this.Invalidate(true);
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

            if (e.Button == MouseButtons.Left)
            {
                List<Rectangle> rect_ = rects.Where(item => item.X < e.X && e.X < item.X + 50 &&item.Y < e.Y && e.Y < item.Y + 50).ToList();
                if (rect_.Count > 0)
                {
                    tmpRect = rect_[0];
                    rects.Remove(rect_[0]);

                    // Increment rectangle-location by mouse-location delta.
                    tmpRect.X += e.X - originalPoint.X;
                    tmpRect.Y += e.Y - originalPoint.Y;
                    rects.Add(tmpRect);
                    // Re-calibrate on each move operation.
                    originalPoint = new MovePoint { X = e.X, Y = e.Y };

                    this.Invalidate(true);
                    //DrawPanel.Refresh();

                }
               
                //findShapeInfo = RecordShapeInfo.Where(item => item.x1 < e.X && e.X < item.x1 + ShapeWidth &&
                //                                          item.y1 < e.Y && e.Y < item.y1 + ShapeHeight).ToList();
                //if (findShapeInfo.Count > 0)
                //{
                //    //changeRectF[0] = findShapeInfo[0].rectF;
                //    float x = findShapeInfo[0].x1;
                //    float y = findShapeInfo[0].y1;
                //    // 紀錄舊資訊
                //    shapeInfo.index = findShapeInfo[0].index;
                //    shapeInfo.age = findShapeInfo[0].age;
                //    shapeInfo.disease = findShapeInfo[0].disease; // 疾病
                //    shapeInfo.status = findShapeInfo[0].status; // 身分地位
                //    shapeInfo.gender = findShapeInfo[0].gender; //性別
                //    // 移除list中舊資料
                //    RecordShapeInfo.Remove(findShapeInfo[0]);

                //    x += e.X - originalPoint.X;
                //    y += e.Y - originalPoint.Y;
                //    // 更新新矩形位置
                //    shapeInfo.x1 = x; shapeInfo.y1 = y;
                //    RecordShapeInfo.Add(shapeInfo);

                //    originalPoint = new MovePoint { X = e.X, Y = e.Y };

                //    this.Invalidate(true);
                //}
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
                maternal_marriage_label.Text = "女方長輩婚姻 : ";
                parent_marriage_label.Visible = false;
                parent_marriage_panel.Visible = false;

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

                paternal_marriage_label.Text = "父方長輩婚姻 : ";
                maternal_marriage_label.Text = "母方長輩婚姻 : ";
                parent_marriage_label.Visible = true;
                parent_marriage_panel.Visible = true;
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
            CalculateInfo();

            //g.DrawEllipse(pen, 3000, 500, 100, 100);
        }

        

        private List<float> DrawParent(float x1, float y, float ShapeDistanceRatio, string MarriageType, int index, string status)
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

            // 長輩婚姻連線
            ConnectMarriageLine(MarriageType, m_parentLineX1, m_parentLineY1, m_parentLineX2, m_parentLineY2);

            // 連接長輩垂直線
            lineX1 = lineX2 = (m_parentLineX1 + m_parentLineX2) / 2;
            lineY1 = m_parentLineY2;
            lineY2 = m_parentLineY2 + lineDropY;
            UpdateShapeInfo(0, "vertical", pen, lineX1, lineY1, lineX2, lineY2);
            slashLine = getSlashXY(slashLine, "vertical", lineX1, lineY1, lineX2, lineY2);
            g.DrawRectangle(pen, m_fatherXpos, m_fatherYpos, ShapeWidth, ShapeHeight);
            g.DrawEllipse(pen, m_motherXpos, m_motherYpos, ShapeWidth, ShapeHeight);
            UpdateShapeInfo(index, "", "unKnown", status, "男", m_fatherXpos, m_fatherYpos, m_fatherXpos + ShapeWidth, m_fatherYpos + ShapeHeight);
            UpdateShapeInfo(index, "", "unKnown", status, "女", m_motherXpos, m_motherYpos, m_motherXpos + ShapeWidth, m_motherYpos + ShapeHeight);

            position.Add(m_fatherXpos); position.Add(m_motherXpos); position.Add(m_fatherYpos);
            return position;
        }

        private void ConnectMarriageLine(string type, float x1, float y1, float x2, float y2)
        {
            switch (type)
            {
                case "結":
                    UpdateShapeInfo(0, "bottom", pen, x1, y1, x2, y2);
                    ConnectShape(pen, "bottom", x1, y1, x2, y2);
                    break;
                case "同":
                    UpdateShapeInfo(0, "bottom", DashStylePen, x1, y1, x2, y2);
                    ConnectShape(DashStylePen, "bottom", x1, y1, x2, y2);
                    break;
                case "分":
                    UpdateShapeInfo(0, "bottom", pen, x1, y1, x2, y2);
                    ConnectShape(pen, "bottom", x1, y1, x2, y2);

                    lineX1 = (x1 + x2) / 2 - slashWidth;
                    lineX2 = (x1 + x2) / 2 + slashWidth;
                    lineY1 = y2 - slashHeight;
                    lineY2 = y2 + slashHeight;
                    UpdateShapeInfo(0, "backslash", pen, lineX1, lineY1, lineX2, lineY2);
                    slashLine = getSlashXY(slashLine, "backslash", lineX1, lineY1, lineX2, lineY2);
                    break;
                case "離":
                    UpdateShapeInfo(0, "bottom", pen, x1, y1, x2, y2);
                    ConnectShape(pen, "bottom", x1, y1, x2, y2);

                    lineX1 = (x1 + x2) / 2 - slashWidth;
                    lineX2 = (x1 + x2) / 2 + slashWidth;
                    lineY1 = y2 - slashHeight;
                    lineY2 = y2 + slashHeight;
                    UpdateShapeInfo(0, "backslash", pen, lineX1, lineY1, lineX2, lineY2);
                    slashLine = getSlashXY(slashLine, "backslash", lineX1, lineY1, lineX2, lineY2);

                    lineX1 = (x1 + x2) / 2 - slashWidth;
                    lineX2 = (x1 + x2) / 2 + slashWidth;
                    lineY1 = y2 + slashHeight;
                    lineY2 = y2 - slashHeight;
                    UpdateShapeInfo(0, "slash", pen, lineX1, lineY1, lineX2, lineY2);
                    slashLine = getSlashXY(slashLine, "slash", lineX1, lineY1, lineX2, lineY2);
                    break;
            }
         
        }

        private string CheckMarriage(bool married, bool cohabit, bool separate, bool divorce)
        {
            string type = married ? "結" : cohabit ? "同" : separate ? "分" : divorce ? "離" : "未";
            return type;
        }

        private void UpdateShapeInfo(int index, string age, string disease, string status, string gender, float x1, float y1, float x2, float y2)
        {
            shapeInfo.index = index;
            shapeInfo.age = age;
            shapeInfo.disease = disease;
            shapeInfo.status = status;
            shapeInfo.gender = gender;
            shapeInfo.x1 = x1; shapeInfo.y1 = y1;
            shapeInfo.x2 = x2; shapeInfo.y2 = y2;
            // 加進紀錄
            RecordShapeInfo.Add(shapeInfo);
            // 清空
            shapeInfo.index = -1;
            shapeInfo.age = "";
            shapeInfo.disease = "";
            shapeInfo.status = "";
            shapeInfo.gender = "";
            shapeInfo.x1 = 0; shapeInfo.y1 = 0;
            shapeInfo.x2 = 0; shapeInfo.y2 = 0;
        }
        private void UpdateShapeInfo(int index, string status, Pen pen ,float x1, float y1, float x2, float y2)
        {
            shapeInfo.index = index;
            shapeInfo.age = "";
            shapeInfo.disease = "";
            shapeInfo.status = status;
            shapeInfo.gender = "";
            shapeInfo.pen = pen;
            shapeInfo.x1 = x1; shapeInfo.y1 = y1;
            shapeInfo.x2 = x2; shapeInfo.y2 = y2;
            // 加進紀錄
            RecordShapeInfo.Add(shapeInfo);
            // 清空
            shapeInfo.index = -1;
            shapeInfo.age = "";
            shapeInfo.disease = "";
            shapeInfo.status = "";
            shapeInfo.gender = "";
            shapeInfo.x1 = 0; shapeInfo.y1 = 0;
            shapeInfo.x2 = 0; shapeInfo.y2 = 0;
        }
        // ===== 圖像計算
        private void CalculateInfo()
        {
            RecordShapeInfo.Clear();
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


            // [個案圖形]
            if (man_radioButton.Checked)
            {
                selfInfo.member += 1;
                // 紀錄矩形資料
                UpdateShapeInfo(0, "", "unKnown", "KeyPerson", "男", selfManXpos, selfManYpos, selfManXpos+ ShapeWidth, selfManYpos+ ShapeHeight);
                g.FillRectangle(KeyPersonBush, selfManXpos, selfManYpos, ShapeWidth, ShapeHeight);
                g.DrawRectangle(pen, selfManXpos, selfManYpos, ShapeWidth, ShapeHeight);

                if (!self_unmarried_radioButton.Checked)
                {
                    UpdateShapeInfo(0, "", "unKnown", "spouse", "女", selfWomanXpos, selfWomanYpos, selfWomanXpos + ShapeWidth, selfWomanYpos + ShapeHeight);
                    g.DrawEllipse(pen, selfWomanXpos, selfWomanYpos, ShapeWidth, ShapeHeight);                    
                }

            }

            if (woman_radioButton.Checked)
            {
                selfInfo.member += 1;
                UpdateShapeInfo(0, "", "unKnown", "KeyPerson", "女", selfWomanXpos, selfWomanYpos, selfWomanXpos + ShapeWidth, selfWomanYpos + ShapeHeight);
                g.FillEllipse(KeyPersonBush, selfWomanXpos, selfWomanYpos, ShapeWidth, ShapeHeight);
                g.DrawEllipse(pen, selfWomanXpos, selfWomanYpos, ShapeWidth, ShapeHeight);

                if (!self_unmarried_radioButton.Checked)
                {
                    UpdateShapeInfo(0, "", "unKnown", "spouse", "男", selfManXpos, selfManYpos, selfManXpos + ShapeWidth, selfManYpos + ShapeHeight);
                    g.DrawRectangle(pen, selfManXpos, selfManYpos, ShapeWidth, ShapeHeight);
                }
            }

            // [個案婚姻連線]
            selfInfo.marriage = CheckMarriage(self_married_radioButton.Checked, self_cohabit_radioButton.Checked, self_separate_radioButton.Checked, self_divorce_radioButton.Checked);
            ConnectMarriageLine(selfInfo.marriage, selfPersonLineX1, selfPersonLineY1, selfPersonLineX2, selfPersonLineY2);


            // [個案爸媽圖形]
            grandparentInfo.paternal_marriage = CheckMarriage(paternal_married_radioButton.Checked, paternal_cohabit_radioButton.Checked, paternal_separate_radioButton.Checked, paternal_divorce_radioButton.Checked);
            grandparentInfo.maternal_marriage = CheckMarriage(maternal_married_radioButton.Checked, maternal_cohabit_radioButton.Checked, maternal_separate_radioButton.Checked, maternal_divorce_radioButton.Checked);

            if (self_relation_parent_radioButton.Checked)
            {               
                DrawParent(selfPersonLineX1, selfManYpos, otherShapeDistanceRatio, grandparentInfo.paternal_marriage, 1, "Paternal GrandParent"); // 男方爸媽
                DrawParent(selfPersonLineX2, selfManYpos, otherShapeDistanceRatio, grandparentInfo.maternal_marriage, 2, "Maternal GrandParent"); // 女方爸媽
            }
            else if (man_radioButton.Checked)
            {                
                parentInfo.marriage = CheckMarriage(parent_married_radioButton.Checked, parent_cohabit_radioButton.Checked, parent_separate_radioButton.Checked, parent_divorce_radioButton.Checked);
                grandparent_Pos = DrawParent(selfPersonLineX1, selfManYpos, otherShapeDistanceRatio*2, parentInfo.marriage, 3, "Parent"); //爸媽
                DrawParent(grandparent_Pos[0] + ShapeWidth / 2, grandparent_Pos[2], otherShapeDistanceRatio, grandparentInfo.paternal_marriage, 1, "Paternal GrandParent"); // 爺爺 阿嬤
                DrawParent(grandparent_Pos[1] + ShapeWidth / 2, grandparent_Pos[2], otherShapeDistanceRatio, grandparentInfo.maternal_marriage, 2, "Maternal GrandParent"); // 外公 外婆
            }
            else if (woman_radioButton.Checked)
            {

                parentInfo.marriage = CheckMarriage(parent_married_radioButton.Checked, parent_cohabit_radioButton.Checked, parent_separate_radioButton.Checked, parent_divorce_radioButton.Checked);
                grandparent_Pos = DrawParent(selfPersonLineX2, selfManYpos, otherShapeDistanceRatio * 2, parentInfo.marriage, 3, "Parent"); //爸媽
                DrawParent(grandparent_Pos[0] + ShapeWidth / 2, grandparent_Pos[2], otherShapeDistanceRatio, grandparentInfo.paternal_marriage, 1, "Paternal GrandParent"); // 爺爺 阿嬤
                DrawParent(grandparent_Pos[1] + ShapeWidth / 2, grandparent_Pos[2], otherShapeDistanceRatio, grandparentInfo.maternal_marriage, 2, "Maternal GrandParent"); // 外公 外婆
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

            // 檢查子女結婚人數
            if (childInfo.marriage.Count > childInfo.member.Count)
            {
                MessageBox.Show("子女結婚人數不正確");
                return;
            }

            // 子女數量>0才需畫圖
            if (childInfo.totalNumber > 0)
            {
                // 連接子女垂直線
                lineX1 = lineX2 = (selfPersonLineX1 + selfPersonLineX2) / 2;
                lineY1 = selfPersonLineY2;
                lineY2 = selfPersonLineY2 + lineDropY;
                UpdateShapeInfo(0, "vertical", pen, lineX1, lineY1, lineX2, lineY2);
                slashLine = getSlashXY(slashLine, "vertical", lineX1, lineY1, lineX2, lineY2);

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
                int startRectIdx = 4;
                foreach (string item in childInfo.member)
                {
                    
                    Xpos = Ratio_x * DrawPanelWidth;
                    if (item == "男")
                    {
                        // index+startRectIdx : 前面有三個矩形已生成
                        UpdateShapeInfo(index + startRectIdx, "", "unKnown", "Child", "男", Xpos, childInfo.Ypos, Xpos + ShapeWidth, childInfo.Ypos + ShapeHeight);
                        g.DrawRectangle(pen, Xpos, childInfo.Ypos, ShapeWidth, ShapeHeight);

                    }
                    else if (item == "女")
                    {
                        UpdateShapeInfo(index + startRectIdx, "", "unKnown", "Child", "女", Xpos, childInfo.Ypos, Xpos + ShapeWidth, childInfo.Ypos + ShapeHeight);
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
                            UpdateShapeInfo(index + startRectIdx, "", "unKnown", "Child", "女", Xpos, childInfo.Ypos, Xpos + ShapeWidth, childInfo.Ypos + ShapeHeight);
                            g.DrawEllipse(pen, Xpos, childInfo.Ypos, ShapeWidth, ShapeHeight);
                        }
                        else if (item == "女")
                        {
                            UpdateShapeInfo(index + startRectIdx, "", "unKnown", "Child", "男", Xpos, childInfo.Ypos, Xpos + ShapeWidth, childInfo.Ypos + ShapeHeight);
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
                    UpdateShapeInfo(0, "top", pen, childInfo.Xpos[idx], childLineY1, childInfo.Xpos[idx + 1], childInfo.Ypos);
                    ConnectShape(pen, "top", childInfo.Xpos[idx], childLineY1, childInfo.Xpos[idx + 1], childInfo.Ypos);
                }

                // 處理子女婚姻的連線狀態
                for (int i = 0; i < childInfo.childmarriageNum; i++)
                {
                    int idx = i * 2;
                    string item = childInfo.marriageType[i];
                    ConnectMarriageLine(item, childInfo.Xpos_marriage[idx], childInfo.Ypos_marriage, childInfo.Xpos_marriage[idx + 1], childInfo.Ypos_marriage + lineDropY);
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
            //if (type == "slash")
            //{
            //    // 斜線
            //    LineInfo.x1 = (x1 + x2) / 2 - slashWidth;
            //    LineInfo.y1 = y2 + slashHeight;
            //    LineInfo.x2 = (x1 + x2) / 2 + slashWidth;
            //    LineInfo.y2 = y2 - slashHeight;           
            //}
            //else if (type == "backslash")
            //{
            //    // 反斜線
            //    LineInfo.x1 = (x1 + x2) / 2 - slashWidth;
            //    LineInfo.y1 = y2 - slashHeight;
            //    LineInfo.x2 = (x1 + x2) / 2 + slashWidth;
            //    LineInfo.y2 = y2 + slashHeight;
            //}
            //else if (type == "vertical")
            //{
            //    // 垂直線
            //    LineInfo.x1 = (x1 + x2) / 2;
            //    LineInfo.y1 = y2;
            //    LineInfo.x2 = (x1 + x2) / 2;
            //    LineInfo.y2 = y2 + lineDropY;
            //}

            LineInfo.x1 = x1;
            LineInfo.y1 = y1;
            LineInfo.x2 = x2;
            LineInfo.y2 = y2;

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

        struct GrandParentInfo
        {
            public int member;
            public string paternal_marriage;  //父方
            public string maternal_marriage;  //母方
        }

        struct SlashLine
        {
            public float x1;
            public float y1;
            public float x2;
            public float y2;
        }

        struct MovePoint
        {
            public int X;
            public int Y;
        }

        struct ShapeInfo
        {
            public int index;
            public string age;
            public string disease; // 疾病
            public string status; // 身分地位;線條
            public string gender; //性別
            public float x1, y1, x2, y2, w, h;
            public Pen pen;
        }

    }
}
