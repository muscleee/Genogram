﻿namespace Genogram
{
    partial class Genogram
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.DrawPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Clear_radioButton = new System.Windows.Forms.RadioButton();
            this.Drag_radioButton = new System.Windows.Forms.RadioButton();
            this.execute_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.self_relation_childern_radioButton = new System.Windows.Forms.RadioButton();
            this.self_relation_parent_radioButton = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.self_unmarried_radioButton = new System.Windows.Forms.RadioButton();
            this.self_separate_radioButton = new System.Windows.Forms.RadioButton();
            this.self_married_radioButton = new System.Windows.Forms.RadioButton();
            this.self_cohabit_radioButton = new System.Windows.Forms.RadioButton();
            this.self_divorce_radioButton = new System.Windows.Forms.RadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.woman_radioButton = new System.Windows.Forms.RadioButton();
            this.man_radioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.parent_marriage_label = new System.Windows.Forms.Label();
            this.parent_marriage_panel = new System.Windows.Forms.Panel();
            this.parent_married_radioButton = new System.Windows.Forms.RadioButton();
            this.parent_separate_radioButton = new System.Windows.Forms.RadioButton();
            this.parent_cohabit_radioButton = new System.Windows.Forms.RadioButton();
            this.parent_divorce_radioButton = new System.Windows.Forms.RadioButton();
            this.maternal_marriage_label = new System.Windows.Forms.Label();
            this.paternal_marriage_label = new System.Windows.Forms.Label();
            this.paternal_marriage_panel = new System.Windows.Forms.Panel();
            this.paternal_separate_radioButton = new System.Windows.Forms.RadioButton();
            this.paternal_married_radioButton = new System.Windows.Forms.RadioButton();
            this.paternal_cohabit_radioButton = new System.Windows.Forms.RadioButton();
            this.paternal_divorce_radioButton = new System.Windows.Forms.RadioButton();
            this.maternal_marriage_panel = new System.Windows.Forms.Panel();
            this.maternal_married_radioButton = new System.Windows.Forms.RadioButton();
            this.maternal_separate_radioButton = new System.Windows.Forms.RadioButton();
            this.maternal_cohabit_radioButton = new System.Windows.Forms.RadioButton();
            this.maternal_divorce_radioButton = new System.Windows.Forms.RadioButton();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.addChild_unmarried_button = new System.Windows.Forms.Button();
            this.addChild_divorce_button = new System.Windows.Forms.Button();
            this.child_textBox = new System.Windows.Forms.TextBox();
            this.addChild_separate_button = new System.Windows.Forms.Button();
            this.addChild_Girl_button = new System.Windows.Forms.Button();
            this.child_marriage_textBox = new System.Windows.Forms.TextBox();
            this.addChild_cohabit_button = new System.Windows.Forms.Button();
            this.addChild_Boy_button = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.addChild_married_button = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.ShapeSize_textBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Draw_radioButton = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.parent_marriage_panel.SuspendLayout();
            this.paternal_marriage_panel.SuspendLayout();
            this.maternal_marriage_panel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // DrawPanel
            // 
            this.DrawPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DrawPanel.Location = new System.Drawing.Point(29, 222);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(952, 551);
            this.DrawPanel.TabIndex = 0;
            this.DrawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPanel_Paint);
            this.DrawPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseDown);
            this.DrawPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseMove);
            this.DrawPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Draw_radioButton);
            this.panel1.Controls.Add(this.Clear_radioButton);
            this.panel1.Controls.Add(this.Drag_radioButton);
            this.panel1.Location = new System.Drawing.Point(29, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(110, 109);
            this.panel1.TabIndex = 1;
            // 
            // Clear_radioButton
            // 
            this.Clear_radioButton.AutoSize = true;
            this.Clear_radioButton.Location = new System.Drawing.Point(20, 74);
            this.Clear_radioButton.Name = "Clear_radioButton";
            this.Clear_radioButton.Size = new System.Drawing.Size(48, 16);
            this.Clear_radioButton.TabIndex = 1;
            this.Clear_radioButton.TabStop = true;
            this.Clear_radioButton.Text = "Clear";
            this.Clear_radioButton.UseVisualStyleBackColor = true;
            this.Clear_radioButton.CheckedChanged += new System.EventHandler(this.Clear_radioButton_CheckedChanged);
            // 
            // Drag_radioButton
            // 
            this.Drag_radioButton.AutoSize = true;
            this.Drag_radioButton.Checked = true;
            this.Drag_radioButton.Location = new System.Drawing.Point(20, 19);
            this.Drag_radioButton.Name = "Drag_radioButton";
            this.Drag_radioButton.Size = new System.Drawing.Size(46, 16);
            this.Drag_radioButton.TabIndex = 2;
            this.Drag_radioButton.TabStop = true;
            this.Drag_radioButton.Text = "Drag";
            this.Drag_radioButton.UseVisualStyleBackColor = true;
            this.Drag_radioButton.CheckedChanged += new System.EventHandler(this.Drag_radioButton_CheckedChanged);
            // 
            // execute_button
            // 
            this.execute_button.Location = new System.Drawing.Point(889, 179);
            this.execute_button.Name = "execute_button";
            this.execute_button.Size = new System.Drawing.Size(75, 23);
            this.execute_button.TabIndex = 4;
            this.execute_button.Text = "執行";
            this.execute_button.UseVisualStyleBackColor = true;
            this.execute_button.Click += new System.EventHandler(this.execute_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "個案 :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel12);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(165, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(330, 90);
            this.panel2.TabIndex = 6;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.self_relation_childern_radioButton);
            this.panel12.Controls.Add(this.self_relation_parent_radioButton);
            this.panel12.Location = new System.Drawing.Point(49, 35);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(118, 22);
            this.panel12.TabIndex = 20;
            // 
            // self_relation_childern_radioButton
            // 
            this.self_relation_childern_radioButton.AutoSize = true;
            this.self_relation_childern_radioButton.Location = new System.Drawing.Point(61, 3);
            this.self_relation_childern_radioButton.Name = "self_relation_childern_radioButton";
            this.self_relation_childern_radioButton.Size = new System.Drawing.Size(47, 16);
            this.self_relation_childern_radioButton.TabIndex = 16;
            this.self_relation_childern_radioButton.TabStop = true;
            this.self_relation_childern_radioButton.Text = "子女";
            this.self_relation_childern_radioButton.UseVisualStyleBackColor = true;
            this.self_relation_childern_radioButton.CheckedChanged += new System.EventHandler(this.self_relation_childern_radioButton_CheckedChanged);
            // 
            // self_relation_parent_radioButton
            // 
            this.self_relation_parent_radioButton.AutoSize = true;
            this.self_relation_parent_radioButton.Location = new System.Drawing.Point(6, 3);
            this.self_relation_parent_radioButton.Name = "self_relation_parent_radioButton";
            this.self_relation_parent_radioButton.Size = new System.Drawing.Size(47, 16);
            this.self_relation_parent_radioButton.TabIndex = 2;
            this.self_relation_parent_radioButton.TabStop = true;
            this.self_relation_parent_radioButton.Text = "父母";
            this.self_relation_parent_radioButton.UseVisualStyleBackColor = true;
            this.self_relation_parent_radioButton.CheckedChanged += new System.EventHandler(this.self_relation_parent_radioButton_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 39);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 12);
            this.label13.TabIndex = 19;
            this.label13.Text = "地位 :";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.self_unmarried_radioButton);
            this.panel7.Controls.Add(this.self_separate_radioButton);
            this.panel7.Controls.Add(this.self_married_radioButton);
            this.panel7.Controls.Add(this.self_cohabit_radioButton);
            this.panel7.Controls.Add(this.self_divorce_radioButton);
            this.panel7.Location = new System.Drawing.Point(49, 61);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(278, 22);
            this.panel7.TabIndex = 17;
            // 
            // self_unmarried_radioButton
            // 
            this.self_unmarried_radioButton.AutoSize = true;
            this.self_unmarried_radioButton.Location = new System.Drawing.Point(6, 3);
            this.self_unmarried_radioButton.Name = "self_unmarried_radioButton";
            this.self_unmarried_radioButton.Size = new System.Drawing.Size(47, 16);
            this.self_unmarried_radioButton.TabIndex = 19;
            this.self_unmarried_radioButton.TabStop = true;
            this.self_unmarried_radioButton.Text = "未婚";
            this.self_unmarried_radioButton.UseVisualStyleBackColor = true;
            // 
            // self_separate_radioButton
            // 
            this.self_separate_radioButton.AutoSize = true;
            this.self_separate_radioButton.Location = new System.Drawing.Point(169, 3);
            this.self_separate_radioButton.Name = "self_separate_radioButton";
            this.self_separate_radioButton.Size = new System.Drawing.Size(47, 16);
            this.self_separate_radioButton.TabIndex = 17;
            this.self_separate_radioButton.TabStop = true;
            this.self_separate_radioButton.Text = "分居";
            this.self_separate_radioButton.UseVisualStyleBackColor = true;
            // 
            // self_married_radioButton
            // 
            this.self_married_radioButton.AutoSize = true;
            this.self_married_radioButton.Location = new System.Drawing.Point(61, 3);
            this.self_married_radioButton.Name = "self_married_radioButton";
            this.self_married_radioButton.Size = new System.Drawing.Size(47, 16);
            this.self_married_radioButton.TabIndex = 2;
            this.self_married_radioButton.TabStop = true;
            this.self_married_radioButton.Text = "結婚";
            this.self_married_radioButton.UseVisualStyleBackColor = true;
            // 
            // self_cohabit_radioButton
            // 
            this.self_cohabit_radioButton.AutoSize = true;
            this.self_cohabit_radioButton.Location = new System.Drawing.Point(116, 3);
            this.self_cohabit_radioButton.Name = "self_cohabit_radioButton";
            this.self_cohabit_radioButton.Size = new System.Drawing.Size(47, 16);
            this.self_cohabit_radioButton.TabIndex = 18;
            this.self_cohabit_radioButton.TabStop = true;
            this.self_cohabit_radioButton.Text = "同居";
            this.self_cohabit_radioButton.UseVisualStyleBackColor = true;
            // 
            // self_divorce_radioButton
            // 
            this.self_divorce_radioButton.AutoSize = true;
            this.self_divorce_radioButton.Location = new System.Drawing.Point(224, 3);
            this.self_divorce_radioButton.Name = "self_divorce_radioButton";
            this.self_divorce_radioButton.Size = new System.Drawing.Size(47, 16);
            this.self_divorce_radioButton.TabIndex = 16;
            this.self_divorce_radioButton.TabStop = true;
            this.self_divorce_radioButton.Text = "離異";
            this.self_divorce_radioButton.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.woman_radioButton);
            this.panel6.Controls.Add(this.man_radioButton);
            this.panel6.Location = new System.Drawing.Point(49, 9);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(118, 22);
            this.panel6.TabIndex = 16;
            // 
            // woman_radioButton
            // 
            this.woman_radioButton.AutoSize = true;
            this.woman_radioButton.Location = new System.Drawing.Point(61, 3);
            this.woman_radioButton.Name = "woman_radioButton";
            this.woman_radioButton.Size = new System.Drawing.Size(35, 16);
            this.woman_radioButton.TabIndex = 16;
            this.woman_radioButton.TabStop = true;
            this.woman_radioButton.Text = "女";
            this.woman_radioButton.UseVisualStyleBackColor = true;
            // 
            // man_radioButton
            // 
            this.man_radioButton.AutoSize = true;
            this.man_radioButton.Location = new System.Drawing.Point(6, 3);
            this.man_radioButton.Name = "man_radioButton";
            this.man_radioButton.Size = new System.Drawing.Size(35, 16);
            this.man_radioButton.TabIndex = 2;
            this.man_radioButton.TabStop = true;
            this.man_radioButton.Text = "男";
            this.man_radioButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "婚姻 :";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.parent_marriage_label);
            this.panel3.Controls.Add(this.parent_marriage_panel);
            this.panel3.Controls.Add(this.maternal_marriage_label);
            this.panel3.Controls.Add(this.paternal_marriage_label);
            this.panel3.Controls.Add(this.paternal_marriage_panel);
            this.panel3.Controls.Add(this.maternal_marriage_panel);
            this.panel3.Location = new System.Drawing.Point(614, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(338, 97);
            this.panel3.TabIndex = 9;
            // 
            // parent_marriage_label
            // 
            this.parent_marriage_label.AutoSize = true;
            this.parent_marriage_label.Location = new System.Drawing.Point(7, 69);
            this.parent_marriage_label.Name = "parent_marriage_label";
            this.parent_marriage_label.Size = new System.Drawing.Size(59, 12);
            this.parent_marriage_label.TabIndex = 25;
            this.parent_marriage_label.Text = "父母婚姻 :";
            // 
            // parent_marriage_panel
            // 
            this.parent_marriage_panel.Controls.Add(this.parent_married_radioButton);
            this.parent_marriage_panel.Controls.Add(this.parent_separate_radioButton);
            this.parent_marriage_panel.Controls.Add(this.parent_cohabit_radioButton);
            this.parent_marriage_panel.Controls.Add(this.parent_divorce_radioButton);
            this.parent_marriage_panel.Location = new System.Drawing.Point(96, 66);
            this.parent_marriage_panel.Name = "parent_marriage_panel";
            this.parent_marriage_panel.Size = new System.Drawing.Size(226, 22);
            this.parent_marriage_panel.TabIndex = 26;
            // 
            // parent_married_radioButton
            // 
            this.parent_married_radioButton.AutoSize = true;
            this.parent_married_radioButton.Location = new System.Drawing.Point(7, 3);
            this.parent_married_radioButton.Name = "parent_married_radioButton";
            this.parent_married_radioButton.Size = new System.Drawing.Size(47, 16);
            this.parent_married_radioButton.TabIndex = 2;
            this.parent_married_radioButton.TabStop = true;
            this.parent_married_radioButton.Text = "結婚";
            this.parent_married_radioButton.UseVisualStyleBackColor = true;
            // 
            // parent_separate_radioButton
            // 
            this.parent_separate_radioButton.AutoSize = true;
            this.parent_separate_radioButton.Location = new System.Drawing.Point(115, 3);
            this.parent_separate_radioButton.Name = "parent_separate_radioButton";
            this.parent_separate_radioButton.Size = new System.Drawing.Size(47, 16);
            this.parent_separate_radioButton.TabIndex = 17;
            this.parent_separate_radioButton.TabStop = true;
            this.parent_separate_radioButton.Text = "分居";
            this.parent_separate_radioButton.UseVisualStyleBackColor = true;
            // 
            // parent_cohabit_radioButton
            // 
            this.parent_cohabit_radioButton.AutoSize = true;
            this.parent_cohabit_radioButton.Location = new System.Drawing.Point(62, 3);
            this.parent_cohabit_radioButton.Name = "parent_cohabit_radioButton";
            this.parent_cohabit_radioButton.Size = new System.Drawing.Size(47, 16);
            this.parent_cohabit_radioButton.TabIndex = 18;
            this.parent_cohabit_radioButton.TabStop = true;
            this.parent_cohabit_radioButton.Text = "同居";
            this.parent_cohabit_radioButton.UseVisualStyleBackColor = true;
            // 
            // parent_divorce_radioButton
            // 
            this.parent_divorce_radioButton.AutoSize = true;
            this.parent_divorce_radioButton.Location = new System.Drawing.Point(170, 3);
            this.parent_divorce_radioButton.Name = "parent_divorce_radioButton";
            this.parent_divorce_radioButton.Size = new System.Drawing.Size(47, 16);
            this.parent_divorce_radioButton.TabIndex = 16;
            this.parent_divorce_radioButton.TabStop = true;
            this.parent_divorce_radioButton.Text = "離異";
            this.parent_divorce_radioButton.UseVisualStyleBackColor = true;
            // 
            // maternal_marriage_label
            // 
            this.maternal_marriage_label.AutoSize = true;
            this.maternal_marriage_label.Location = new System.Drawing.Point(7, 41);
            this.maternal_marriage_label.Name = "maternal_marriage_label";
            this.maternal_marriage_label.Size = new System.Drawing.Size(83, 12);
            this.maternal_marriage_label.TabIndex = 8;
            this.maternal_marriage_label.Text = "女方長輩婚姻 :";
            // 
            // paternal_marriage_label
            // 
            this.paternal_marriage_label.AutoSize = true;
            this.paternal_marriage_label.Location = new System.Drawing.Point(7, 14);
            this.paternal_marriage_label.Name = "paternal_marriage_label";
            this.paternal_marriage_label.Size = new System.Drawing.Size(83, 12);
            this.paternal_marriage_label.TabIndex = 5;
            this.paternal_marriage_label.Text = "男方長輩婚姻 :";
            // 
            // paternal_marriage_panel
            // 
            this.paternal_marriage_panel.Controls.Add(this.paternal_separate_radioButton);
            this.paternal_marriage_panel.Controls.Add(this.paternal_married_radioButton);
            this.paternal_marriage_panel.Controls.Add(this.paternal_cohabit_radioButton);
            this.paternal_marriage_panel.Controls.Add(this.paternal_divorce_radioButton);
            this.paternal_marriage_panel.Location = new System.Drawing.Point(96, 9);
            this.paternal_marriage_panel.Name = "paternal_marriage_panel";
            this.paternal_marriage_panel.Size = new System.Drawing.Size(226, 22);
            this.paternal_marriage_panel.TabIndex = 23;
            // 
            // paternal_separate_radioButton
            // 
            this.paternal_separate_radioButton.AutoSize = true;
            this.paternal_separate_radioButton.Location = new System.Drawing.Point(115, 3);
            this.paternal_separate_radioButton.Name = "paternal_separate_radioButton";
            this.paternal_separate_radioButton.Size = new System.Drawing.Size(47, 16);
            this.paternal_separate_radioButton.TabIndex = 17;
            this.paternal_separate_radioButton.TabStop = true;
            this.paternal_separate_radioButton.Text = "分居";
            this.paternal_separate_radioButton.UseVisualStyleBackColor = true;
            // 
            // paternal_married_radioButton
            // 
            this.paternal_married_radioButton.AutoSize = true;
            this.paternal_married_radioButton.Location = new System.Drawing.Point(7, 3);
            this.paternal_married_radioButton.Name = "paternal_married_radioButton";
            this.paternal_married_radioButton.Size = new System.Drawing.Size(47, 16);
            this.paternal_married_radioButton.TabIndex = 2;
            this.paternal_married_radioButton.TabStop = true;
            this.paternal_married_radioButton.Text = "結婚";
            this.paternal_married_radioButton.UseVisualStyleBackColor = true;
            // 
            // paternal_cohabit_radioButton
            // 
            this.paternal_cohabit_radioButton.AutoSize = true;
            this.paternal_cohabit_radioButton.Location = new System.Drawing.Point(62, 3);
            this.paternal_cohabit_radioButton.Name = "paternal_cohabit_radioButton";
            this.paternal_cohabit_radioButton.Size = new System.Drawing.Size(47, 16);
            this.paternal_cohabit_radioButton.TabIndex = 18;
            this.paternal_cohabit_radioButton.TabStop = true;
            this.paternal_cohabit_radioButton.Text = "同居";
            this.paternal_cohabit_radioButton.UseVisualStyleBackColor = true;
            // 
            // paternal_divorce_radioButton
            // 
            this.paternal_divorce_radioButton.AutoSize = true;
            this.paternal_divorce_radioButton.Location = new System.Drawing.Point(170, 3);
            this.paternal_divorce_radioButton.Name = "paternal_divorce_radioButton";
            this.paternal_divorce_radioButton.Size = new System.Drawing.Size(47, 16);
            this.paternal_divorce_radioButton.TabIndex = 16;
            this.paternal_divorce_radioButton.TabStop = true;
            this.paternal_divorce_radioButton.Text = "離異";
            this.paternal_divorce_radioButton.UseVisualStyleBackColor = true;
            // 
            // maternal_marriage_panel
            // 
            this.maternal_marriage_panel.Controls.Add(this.maternal_married_radioButton);
            this.maternal_marriage_panel.Controls.Add(this.maternal_separate_radioButton);
            this.maternal_marriage_panel.Controls.Add(this.maternal_cohabit_radioButton);
            this.maternal_marriage_panel.Controls.Add(this.maternal_divorce_radioButton);
            this.maternal_marriage_panel.Location = new System.Drawing.Point(96, 38);
            this.maternal_marriage_panel.Name = "maternal_marriage_panel";
            this.maternal_marriage_panel.Size = new System.Drawing.Size(226, 22);
            this.maternal_marriage_panel.TabIndex = 24;
            // 
            // maternal_married_radioButton
            // 
            this.maternal_married_radioButton.AutoSize = true;
            this.maternal_married_radioButton.Location = new System.Drawing.Point(7, 3);
            this.maternal_married_radioButton.Name = "maternal_married_radioButton";
            this.maternal_married_radioButton.Size = new System.Drawing.Size(47, 16);
            this.maternal_married_radioButton.TabIndex = 2;
            this.maternal_married_radioButton.TabStop = true;
            this.maternal_married_radioButton.Text = "結婚";
            this.maternal_married_radioButton.UseVisualStyleBackColor = true;
            // 
            // maternal_separate_radioButton
            // 
            this.maternal_separate_radioButton.AutoSize = true;
            this.maternal_separate_radioButton.Location = new System.Drawing.Point(115, 3);
            this.maternal_separate_radioButton.Name = "maternal_separate_radioButton";
            this.maternal_separate_radioButton.Size = new System.Drawing.Size(47, 16);
            this.maternal_separate_radioButton.TabIndex = 17;
            this.maternal_separate_radioButton.TabStop = true;
            this.maternal_separate_radioButton.Text = "分居";
            this.maternal_separate_radioButton.UseVisualStyleBackColor = true;
            // 
            // maternal_cohabit_radioButton
            // 
            this.maternal_cohabit_radioButton.AutoSize = true;
            this.maternal_cohabit_radioButton.Location = new System.Drawing.Point(62, 3);
            this.maternal_cohabit_radioButton.Name = "maternal_cohabit_radioButton";
            this.maternal_cohabit_radioButton.Size = new System.Drawing.Size(47, 16);
            this.maternal_cohabit_radioButton.TabIndex = 18;
            this.maternal_cohabit_radioButton.TabStop = true;
            this.maternal_cohabit_radioButton.Text = "同居";
            this.maternal_cohabit_radioButton.UseVisualStyleBackColor = true;
            // 
            // maternal_divorce_radioButton
            // 
            this.maternal_divorce_radioButton.AutoSize = true;
            this.maternal_divorce_radioButton.Location = new System.Drawing.Point(170, 3);
            this.maternal_divorce_radioButton.Name = "maternal_divorce_radioButton";
            this.maternal_divorce_radioButton.Size = new System.Drawing.Size(47, 16);
            this.maternal_divorce_radioButton.TabIndex = 16;
            this.maternal_divorce_radioButton.TabStop = true;
            this.maternal_divorce_radioButton.Text = "離異";
            this.maternal_divorce_radioButton.UseVisualStyleBackColor = true;
            // 
            // comboBox4
            // 
            this.comboBox4.AutoCompleteCustomSource.AddRange(new string[] {
            "已婚",
            "離婚"});
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(167, 179);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(51, 20);
            this.comboBox4.TabIndex = 10;
            this.comboBox4.Text = "已婚";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(113, 181);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(48, 16);
            this.checkBox4.TabIndex = 9;
            this.checkBox4.Text = "未婚";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "婚姻 :";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.checkBox8);
            this.panel4.Controls.Add(this.checkBox9);
            this.panel4.Controls.Add(this.checkBox10);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.checkBox11);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(224, 53);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(224, 68);
            this.panel4.TabIndex = 15;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(161, 37);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(48, 16);
            this.checkBox8.TabIndex = 13;
            this.checkBox8.Text = "離異";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(106, 37);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(48, 16);
            this.checkBox9.TabIndex = 12;
            this.checkBox9.Text = "已婚";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(161, 12);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(48, 16);
            this.checkBox10.TabIndex = 11;
            this.checkBox10.Text = "離異";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "女方長輩婚姻 :";
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(106, 12);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(48, 16);
            this.checkBox11.TabIndex = 10;
            this.checkBox11.Text = "已婚";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "男方長輩婚姻 :";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.checkBox12);
            this.panel5.Controls.Add(this.checkBox13);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.checkBox14);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.checkBox15);
            this.panel5.Location = new System.Drawing.Point(32, 53);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(170, 68);
            this.panel5.TabIndex = 14;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(111, 40);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(48, 16);
            this.checkBox12.TabIndex = 9;
            this.checkBox12.Text = "離異";
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // checkBox13
            // 
            this.checkBox13.AutoSize = true;
            this.checkBox13.Location = new System.Drawing.Point(56, 40);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(48, 16);
            this.checkBox13.TabIndex = 6;
            this.checkBox13.Text = "已婚";
            this.checkBox13.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "婚姻 :";
            // 
            // checkBox14
            // 
            this.checkBox14.AutoSize = true;
            this.checkBox14.Location = new System.Drawing.Point(56, 12);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(36, 16);
            this.checkBox14.TabIndex = 2;
            this.checkBox14.Text = "男";
            this.checkBox14.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "個案 :";
            // 
            // checkBox15
            // 
            this.checkBox15.AutoSize = true;
            this.checkBox15.Location = new System.Drawing.Point(111, 12);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(36, 16);
            this.checkBox15.TabIndex = 3;
            this.checkBox15.Text = "女";
            this.checkBox15.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panel5);
            this.panel10.Controls.Add(this.panel4);
            this.panel10.Controls.Add(this.label5);
            this.panel10.Controls.Add(this.comboBox4);
            this.panel10.Controls.Add(this.checkBox4);
            this.panel10.Location = new System.Drawing.Point(987, 48);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(421, 257);
            this.panel10.TabIndex = 16;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.addChild_unmarried_button);
            this.panel11.Controls.Add(this.addChild_divorce_button);
            this.panel11.Controls.Add(this.child_textBox);
            this.panel11.Controls.Add(this.addChild_separate_button);
            this.panel11.Controls.Add(this.addChild_Girl_button);
            this.panel11.Controls.Add(this.child_marriage_textBox);
            this.panel11.Controls.Add(this.addChild_cohabit_button);
            this.panel11.Controls.Add(this.addChild_Boy_button);
            this.panel11.Controls.Add(this.label10);
            this.panel11.Controls.Add(this.addChild_married_button);
            this.panel11.Controls.Add(this.label11);
            this.panel11.Location = new System.Drawing.Point(165, 128);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(444, 74);
            this.panel11.TabIndex = 17;
            // 
            // addChild_unmarried_button
            // 
            this.addChild_unmarried_button.Location = new System.Drawing.Point(203, 39);
            this.addChild_unmarried_button.Name = "addChild_unmarried_button";
            this.addChild_unmarried_button.Size = new System.Drawing.Size(37, 23);
            this.addChild_unmarried_button.TabIndex = 26;
            this.addChild_unmarried_button.Text = " + 未";
            this.addChild_unmarried_button.UseVisualStyleBackColor = true;
            this.addChild_unmarried_button.Click += new System.EventHandler(this.addChild_unmarried_button_Click);
            // 
            // addChild_divorce_button
            // 
            this.addChild_divorce_button.Location = new System.Drawing.Point(383, 39);
            this.addChild_divorce_button.Name = "addChild_divorce_button";
            this.addChild_divorce_button.Size = new System.Drawing.Size(37, 23);
            this.addChild_divorce_button.TabIndex = 25;
            this.addChild_divorce_button.Text = " + 離";
            this.addChild_divorce_button.UseVisualStyleBackColor = true;
            this.addChild_divorce_button.Click += new System.EventHandler(this.addChild_divorce_button_Click);
            // 
            // child_textBox
            // 
            this.child_textBox.Location = new System.Drawing.Point(49, 8);
            this.child_textBox.Name = "child_textBox";
            this.child_textBox.Size = new System.Drawing.Size(148, 22);
            this.child_textBox.TabIndex = 20;
            // 
            // addChild_separate_button
            // 
            this.addChild_separate_button.Location = new System.Drawing.Point(338, 39);
            this.addChild_separate_button.Name = "addChild_separate_button";
            this.addChild_separate_button.Size = new System.Drawing.Size(37, 23);
            this.addChild_separate_button.TabIndex = 24;
            this.addChild_separate_button.Text = " + 分";
            this.addChild_separate_button.UseVisualStyleBackColor = true;
            this.addChild_separate_button.Click += new System.EventHandler(this.addChild_separate_button_Click);
            // 
            // addChild_Girl_button
            // 
            this.addChild_Girl_button.Location = new System.Drawing.Point(248, 8);
            this.addChild_Girl_button.Name = "addChild_Girl_button";
            this.addChild_Girl_button.Size = new System.Drawing.Size(37, 23);
            this.addChild_Girl_button.TabIndex = 19;
            this.addChild_Girl_button.Text = " + 女";
            this.addChild_Girl_button.UseVisualStyleBackColor = true;
            this.addChild_Girl_button.Click += new System.EventHandler(this.addChild_Girl_button_Click);
            // 
            // child_marriage_textBox
            // 
            this.child_marriage_textBox.Location = new System.Drawing.Point(48, 39);
            this.child_marriage_textBox.Name = "child_marriage_textBox";
            this.child_marriage_textBox.Size = new System.Drawing.Size(148, 22);
            this.child_marriage_textBox.TabIndex = 23;
            // 
            // addChild_cohabit_button
            // 
            this.addChild_cohabit_button.Location = new System.Drawing.Point(293, 39);
            this.addChild_cohabit_button.Name = "addChild_cohabit_button";
            this.addChild_cohabit_button.Size = new System.Drawing.Size(37, 23);
            this.addChild_cohabit_button.TabIndex = 22;
            this.addChild_cohabit_button.Text = " + 同";
            this.addChild_cohabit_button.UseVisualStyleBackColor = true;
            this.addChild_cohabit_button.Click += new System.EventHandler(this.addChild_cohabit_button_Click);
            // 
            // addChild_Boy_button
            // 
            this.addChild_Boy_button.Location = new System.Drawing.Point(203, 8);
            this.addChild_Boy_button.Name = "addChild_Boy_button";
            this.addChild_Boy_button.Size = new System.Drawing.Size(37, 23);
            this.addChild_Boy_button.TabIndex = 18;
            this.addChild_Boy_button.Text = " + 男";
            this.addChild_Boy_button.UseVisualStyleBackColor = true;
            this.addChild_Boy_button.Click += new System.EventHandler(this.addChild_Boy_button_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "婚姻 :";
            // 
            // addChild_married_button
            // 
            this.addChild_married_button.Location = new System.Drawing.Point(248, 39);
            this.addChild_married_button.Name = "addChild_married_button";
            this.addChild_married_button.Size = new System.Drawing.Size(37, 23);
            this.addChild_married_button.TabIndex = 21;
            this.addChild_married_button.Text = " + 結";
            this.addChild_married_button.UseVisualStyleBackColor = true;
            this.addChild_married_button.Click += new System.EventHandler(this.addChild_married_button_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 5;
            this.label11.Text = "子女 :";
            // 
            // ShapeSize_textBox
            // 
            this.ShapeSize_textBox.Location = new System.Drawing.Point(69, 167);
            this.ShapeSize_textBox.Name = "ShapeSize_textBox";
            this.ShapeSize_textBox.Size = new System.Drawing.Size(70, 22);
            this.ShapeSize_textBox.TabIndex = 22;
            this.ShapeSize_textBox.TextChanged += new System.EventHandler(this.ShapeSize_textBox_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 173);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 21;
            this.label12.Text = "大小 :";
            // 
            // Draw_radioButton
            // 
            this.Draw_radioButton.AutoSize = true;
            this.Draw_radioButton.Location = new System.Drawing.Point(20, 47);
            this.Draw_radioButton.Name = "Draw_radioButton";
            this.Draw_radioButton.Size = new System.Drawing.Size(48, 16);
            this.Draw_radioButton.TabIndex = 3;
            this.Draw_radioButton.TabStop = true;
            this.Draw_radioButton.Text = "Draw";
            this.Draw_radioButton.UseVisualStyleBackColor = true;
            this.Draw_radioButton.CheckedChanged += new System.EventHandler(this.Draw_radioButton_CheckedChanged);
            // 
            // Genogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1014, 822);
            this.Controls.Add(this.ShapeSize_textBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.execute_button);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DrawPanel);
            this.Name = "Genogram";
            this.Text = " ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.parent_marriage_panel.ResumeLayout(false);
            this.parent_marriage_panel.PerformLayout();
            this.paternal_marriage_panel.ResumeLayout(false);
            this.paternal_marriage_panel.PerformLayout();
            this.maternal_marriage_panel.ResumeLayout(false);
            this.maternal_marriage_panel.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel DrawPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton Clear_radioButton;
        private System.Windows.Forms.Button execute_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton woman_radioButton;
        private System.Windows.Forms.RadioButton man_radioButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label maternal_marriage_label;
        private System.Windows.Forms.Label paternal_marriage_label;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox15;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.RadioButton self_divorce_radioButton;
        private System.Windows.Forms.RadioButton self_married_radioButton;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RadioButton Drag_radioButton;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.RadioButton self_separate_radioButton;
        private System.Windows.Forms.RadioButton self_cohabit_radioButton;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button addChild_divorce_button;
        private System.Windows.Forms.TextBox child_textBox;
        private System.Windows.Forms.Button addChild_separate_button;
        private System.Windows.Forms.Button addChild_Girl_button;
        private System.Windows.Forms.TextBox child_marriage_textBox;
        private System.Windows.Forms.Button addChild_cohabit_button;
        private System.Windows.Forms.Button addChild_Boy_button;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button addChild_married_button;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button addChild_unmarried_button;
        private System.Windows.Forms.TextBox ShapeSize_textBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.RadioButton self_relation_childern_radioButton;
        private System.Windows.Forms.RadioButton self_relation_parent_radioButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton self_unmarried_radioButton;
        private System.Windows.Forms.Panel paternal_marriage_panel;
        private System.Windows.Forms.RadioButton paternal_separate_radioButton;
        private System.Windows.Forms.RadioButton paternal_married_radioButton;
        private System.Windows.Forms.RadioButton paternal_cohabit_radioButton;
        private System.Windows.Forms.RadioButton paternal_divorce_radioButton;
        private System.Windows.Forms.Panel maternal_marriage_panel;
        private System.Windows.Forms.RadioButton maternal_married_radioButton;
        private System.Windows.Forms.RadioButton maternal_separate_radioButton;
        private System.Windows.Forms.RadioButton maternal_cohabit_radioButton;
        private System.Windows.Forms.RadioButton maternal_divorce_radioButton;
        private System.Windows.Forms.Label parent_marriage_label;
        private System.Windows.Forms.Panel parent_marriage_panel;
        private System.Windows.Forms.RadioButton parent_married_radioButton;
        private System.Windows.Forms.RadioButton parent_separate_radioButton;
        private System.Windows.Forms.RadioButton parent_cohabit_radioButton;
        private System.Windows.Forms.RadioButton parent_divorce_radioButton;
        private System.Windows.Forms.RadioButton Draw_radioButton;
    }
}

