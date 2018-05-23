namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.glControl1 = new OpenTK.GLControl();
            this.buttonDivideNMK = new System.Windows.Forms.Button();
            this.labelN = new System.Windows.Forms.Label();
            this.labelM = new System.Windows.Forms.Label();
            this.labelK = new System.Windows.Forms.Label();
            this.textBoxN = new System.Windows.Forms.TextBox();
            this.textBoxK = new System.Windows.Forms.TextBox();
            this.textBoxM = new System.Windows.Forms.TextBox();
            this.buttonScalePlus = new System.Windows.Forms.Button();
            this.buttonScaleMinus = new System.Windows.Forms.Button();
            this.labelScale = new System.Windows.Forms.Label();
            this.buttonRotateZPlus = new System.Windows.Forms.Button();
            this.buttonRotateYMinus = new System.Windows.Forms.Button();
            this.buttonRotateYPlus = new System.Windows.Forms.Button();
            this.buttonRotateXMinus = new System.Windows.Forms.Button();
            this.buttonRotateXPlus = new System.Windows.Forms.Button();
            this.buttonRotateZMinus = new System.Windows.Forms.Button();
            this.labelRotateZ = new System.Windows.Forms.Label();
            this.labelRotateY = new System.Windows.Forms.Label();
            this.labelRotateX = new System.Windows.Forms.Label();
            this.textBoxNodeCOunt = new System.Windows.Forms.TextBox();
            this.textBoxIsNormCount = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxChooseNode = new System.Windows.Forms.ComboBox();
            this.buttonTexture = new System.Windows.Forms.Button();
            this.buttonColorfulQuads = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(15, 14);
            this.glControl1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(636, 489);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            // 
            // buttonDivideNMK
            // 
            this.buttonDivideNMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDivideNMK.Location = new System.Drawing.Point(838, 39);
            this.buttonDivideNMK.Name = "buttonDivideNMK";
            this.buttonDivideNMK.Size = new System.Drawing.Size(176, 55);
            this.buttonDivideNMK.TabIndex = 1;
            this.buttonDivideNMK.Text = "Divide on n*m*k";
            this.buttonDivideNMK.UseVisualStyleBackColor = true;
            this.buttonDivideNMK.Click += new System.EventHandler(this.buttonDivideNMK_Click);
            // 
            // labelN
            // 
            this.labelN.AutoSize = true;
            this.labelN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelN.Location = new System.Drawing.Point(664, 14);
            this.labelN.Name = "labelN";
            this.labelN.Size = new System.Drawing.Size(45, 25);
            this.labelN.TabIndex = 3;
            this.labelN.Text = "n = ";
            // 
            // labelM
            // 
            this.labelM.AutoSize = true;
            this.labelM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelM.Location = new System.Drawing.Point(665, 53);
            this.labelM.Name = "labelM";
            this.labelM.Size = new System.Drawing.Size(50, 25);
            this.labelM.TabIndex = 4;
            this.labelM.Text = "m = ";
            // 
            // labelK
            // 
            this.labelK.AutoSize = true;
            this.labelK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelK.Location = new System.Drawing.Point(665, 93);
            this.labelK.Name = "labelK";
            this.labelK.Size = new System.Drawing.Size(44, 25);
            this.labelK.TabIndex = 5;
            this.labelK.Text = "k = ";
            // 
            // textBoxN
            // 
            this.textBoxN.Location = new System.Drawing.Point(710, 14);
            this.textBoxN.Name = "textBoxN";
            this.textBoxN.Size = new System.Drawing.Size(76, 26);
            this.textBoxN.TabIndex = 6;
            this.textBoxN.Text = "1";
            // 
            // textBoxK
            // 
            this.textBoxK.Location = new System.Drawing.Point(710, 94);
            this.textBoxK.Name = "textBoxK";
            this.textBoxK.Size = new System.Drawing.Size(76, 26);
            this.textBoxK.TabIndex = 7;
            this.textBoxK.Text = "1";
            // 
            // textBoxM
            // 
            this.textBoxM.Location = new System.Drawing.Point(710, 54);
            this.textBoxM.Name = "textBoxM";
            this.textBoxM.Size = new System.Drawing.Size(76, 26);
            this.textBoxM.TabIndex = 8;
            this.textBoxM.Text = "1";
            // 
            // buttonScalePlus
            // 
            this.buttonScalePlus.Location = new System.Drawing.Point(660, 148);
            this.buttonScalePlus.Name = "buttonScalePlus";
            this.buttonScalePlus.Size = new System.Drawing.Size(49, 33);
            this.buttonScalePlus.TabIndex = 9;
            this.buttonScalePlus.Text = "+";
            this.buttonScalePlus.UseVisualStyleBackColor = true;
            this.buttonScalePlus.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // buttonScaleMinus
            // 
            this.buttonScaleMinus.Location = new System.Drawing.Point(725, 148);
            this.buttonScaleMinus.Name = "buttonScaleMinus";
            this.buttonScaleMinus.Size = new System.Drawing.Size(49, 33);
            this.buttonScaleMinus.TabIndex = 10;
            this.buttonScaleMinus.Text = "-";
            this.buttonScaleMinus.UseVisualStyleBackColor = true;
            this.buttonScaleMinus.Click += new System.EventHandler(this.buttonMinus_Click);
            // 
            // labelScale
            // 
            this.labelScale.AutoSize = true;
            this.labelScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelScale.Location = new System.Drawing.Point(794, 150);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(62, 25);
            this.labelScale.TabIndex = 11;
            this.labelScale.Text = "Scale";
            // 
            // buttonRotateZPlus
            // 
            this.buttonRotateZPlus.Location = new System.Drawing.Point(660, 294);
            this.buttonRotateZPlus.Name = "buttonRotateZPlus";
            this.buttonRotateZPlus.Size = new System.Drawing.Size(49, 33);
            this.buttonRotateZPlus.TabIndex = 12;
            this.buttonRotateZPlus.Text = "+";
            this.buttonRotateZPlus.UseVisualStyleBackColor = true;
            this.buttonRotateZPlus.Click += new System.EventHandler(this.buttonRotateZPlus_Click);
            // 
            // buttonRotateYMinus
            // 
            this.buttonRotateYMinus.Location = new System.Drawing.Point(725, 246);
            this.buttonRotateYMinus.Name = "buttonRotateYMinus";
            this.buttonRotateYMinus.Size = new System.Drawing.Size(49, 33);
            this.buttonRotateYMinus.TabIndex = 13;
            this.buttonRotateYMinus.Text = "-";
            this.buttonRotateYMinus.UseVisualStyleBackColor = true;
            this.buttonRotateYMinus.Click += new System.EventHandler(this.buttonRotateYMinus_Click);
            // 
            // buttonRotateYPlus
            // 
            this.buttonRotateYPlus.Location = new System.Drawing.Point(660, 246);
            this.buttonRotateYPlus.Name = "buttonRotateYPlus";
            this.buttonRotateYPlus.Size = new System.Drawing.Size(49, 33);
            this.buttonRotateYPlus.TabIndex = 14;
            this.buttonRotateYPlus.Text = "+";
            this.buttonRotateYPlus.UseVisualStyleBackColor = true;
            this.buttonRotateYPlus.Click += new System.EventHandler(this.buttonRotateYPlus_Click);
            // 
            // buttonRotateXMinus
            // 
            this.buttonRotateXMinus.Location = new System.Drawing.Point(725, 198);
            this.buttonRotateXMinus.Name = "buttonRotateXMinus";
            this.buttonRotateXMinus.Size = new System.Drawing.Size(49, 33);
            this.buttonRotateXMinus.TabIndex = 15;
            this.buttonRotateXMinus.Text = "-";
            this.buttonRotateXMinus.UseVisualStyleBackColor = true;
            this.buttonRotateXMinus.Click += new System.EventHandler(this.buttonRotateXMinus_Click);
            // 
            // buttonRotateXPlus
            // 
            this.buttonRotateXPlus.Location = new System.Drawing.Point(660, 198);
            this.buttonRotateXPlus.Name = "buttonRotateXPlus";
            this.buttonRotateXPlus.Size = new System.Drawing.Size(49, 33);
            this.buttonRotateXPlus.TabIndex = 16;
            this.buttonRotateXPlus.Text = "+";
            this.buttonRotateXPlus.UseVisualStyleBackColor = true;
            this.buttonRotateXPlus.Click += new System.EventHandler(this.buttonRotateXPlus_Click);
            // 
            // buttonRotateZMinus
            // 
            this.buttonRotateZMinus.Location = new System.Drawing.Point(725, 294);
            this.buttonRotateZMinus.Name = "buttonRotateZMinus";
            this.buttonRotateZMinus.Size = new System.Drawing.Size(49, 33);
            this.buttonRotateZMinus.TabIndex = 17;
            this.buttonRotateZMinus.Text = "-";
            this.buttonRotateZMinus.UseVisualStyleBackColor = true;
            this.buttonRotateZMinus.Click += new System.EventHandler(this.buttonRotateZMinus_Click);
            // 
            // labelRotateZ
            // 
            this.labelRotateZ.AutoSize = true;
            this.labelRotateZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRotateZ.Location = new System.Drawing.Point(794, 294);
            this.labelRotateZ.Name = "labelRotateZ";
            this.labelRotateZ.Size = new System.Drawing.Size(83, 25);
            this.labelRotateZ.TabIndex = 18;
            this.labelRotateZ.Text = "Rotate z";
            // 
            // labelRotateY
            // 
            this.labelRotateY.AutoSize = true;
            this.labelRotateY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRotateY.Location = new System.Drawing.Point(794, 248);
            this.labelRotateY.Name = "labelRotateY";
            this.labelRotateY.Size = new System.Drawing.Size(83, 25);
            this.labelRotateY.TabIndex = 19;
            this.labelRotateY.Text = "Rotate y";
            // 
            // labelRotateX
            // 
            this.labelRotateX.AutoSize = true;
            this.labelRotateX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRotateX.Location = new System.Drawing.Point(794, 198);
            this.labelRotateX.Name = "labelRotateX";
            this.labelRotateX.Size = new System.Drawing.Size(83, 25);
            this.labelRotateX.TabIndex = 20;
            this.labelRotateX.Text = "Rotate x";
            // 
            // textBoxNodeCOunt
            // 
            this.textBoxNodeCOunt.Location = new System.Drawing.Point(939, 205);
            this.textBoxNodeCOunt.Name = "textBoxNodeCOunt";
            this.textBoxNodeCOunt.Size = new System.Drawing.Size(100, 26);
            this.textBoxNodeCOunt.TabIndex = 21;
            // 
            // textBoxIsNormCount
            // 
            this.textBoxIsNormCount.Location = new System.Drawing.Point(1056, 205);
            this.textBoxIsNormCount.Name = "textBoxIsNormCount";
            this.textBoxIsNormCount.Size = new System.Drawing.Size(100, 26);
            this.textBoxIsNormCount.TabIndex = 22;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.X,
            this.Y,
            this.Z});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView1.Location = new System.Drawing.Point(660, 353);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 15;
            this.dataGridView1.RowTemplate.Height = 15;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(370, 288);
            this.dataGridView1.TabIndex = 24;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 35;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.Width = 60;
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            this.Y.Width = 60;
            // 
            // Z
            // 
            this.Z.HeaderText = "Z";
            this.Z.Name = "Z";
            this.Z.Width = 60;
            // 
            // comboBoxChooseNode
            // 
            this.comboBoxChooseNode.FormattingEnabled = true;
            this.comboBoxChooseNode.Location = new System.Drawing.Point(1056, 353);
            this.comboBoxChooseNode.Name = "comboBoxChooseNode";
            this.comboBoxChooseNode.Size = new System.Drawing.Size(121, 28);
            this.comboBoxChooseNode.TabIndex = 27;
            this.comboBoxChooseNode.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // buttonTexture
            // 
            this.buttonTexture.Location = new System.Drawing.Point(12, 666);
            this.buttonTexture.Name = "buttonTexture";
            this.buttonTexture.Size = new System.Drawing.Size(124, 45);
            this.buttonTexture.TabIndex = 28;
            this.buttonTexture.Text = "Texture";
            this.buttonTexture.UseVisualStyleBackColor = true;
            this.buttonTexture.Click += new System.EventHandler(this.buttonTexture_Click);
            // 
            // buttonColorfulQuads
            // 
            this.buttonColorfulQuads.Location = new System.Drawing.Point(177, 541);
            this.buttonColorfulQuads.Name = "buttonColorfulQuads";
            this.buttonColorfulQuads.Size = new System.Drawing.Size(103, 45);
            this.buttonColorfulQuads.TabIndex = 29;
            this.buttonColorfulQuads.Text = "buttonColorfulQuads";
            this.buttonColorfulQuads.UseVisualStyleBackColor = true;
            this.buttonColorfulQuads.Click += new System.EventHandler(this.buttonColorfulQuads_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 515);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(113, 24);
            this.checkBox1.TabIndex = 30;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(13, 541);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(113, 24);
            this.checkBox2.TabIndex = 31;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(12, 571);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(113, 24);
            this.checkBox3.TabIndex = 32;
            this.checkBox3.Text = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(13, 603);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(113, 24);
            this.checkBox4.TabIndex = 33;
            this.checkBox4.Text = "checkBox4";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(13, 634);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(113, 24);
            this.checkBox5.TabIndex = 34;
            this.checkBox5.Text = "checkBox5";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 723);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.buttonColorfulQuads);
            this.Controls.Add(this.buttonTexture);
            this.Controls.Add(this.comboBoxChooseNode);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxIsNormCount);
            this.Controls.Add(this.textBoxNodeCOunt);
            this.Controls.Add(this.labelRotateX);
            this.Controls.Add(this.labelRotateY);
            this.Controls.Add(this.labelRotateZ);
            this.Controls.Add(this.buttonRotateZMinus);
            this.Controls.Add(this.buttonRotateXPlus);
            this.Controls.Add(this.buttonRotateXMinus);
            this.Controls.Add(this.buttonRotateYPlus);
            this.Controls.Add(this.buttonRotateYMinus);
            this.Controls.Add(this.buttonRotateZPlus);
            this.Controls.Add(this.labelScale);
            this.Controls.Add(this.buttonScaleMinus);
            this.Controls.Add(this.buttonScalePlus);
            this.Controls.Add(this.textBoxM);
            this.Controls.Add(this.textBoxK);
            this.Controls.Add(this.textBoxN);
            this.Controls.Add(this.labelK);
            this.Controls.Add(this.labelM);
            this.Controls.Add(this.labelN);
            this.Controls.Add(this.buttonDivideNMK);
            this.Controls.Add(this.glControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "3D modeling";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.Button buttonDivideNMK;
        private System.Windows.Forms.Label labelN;
        private System.Windows.Forms.Label labelM;
        private System.Windows.Forms.Label labelK;
        private System.Windows.Forms.TextBox textBoxN;
        private System.Windows.Forms.TextBox textBoxK;
        private System.Windows.Forms.TextBox textBoxM;
        private System.Windows.Forms.Button buttonScalePlus;
        private System.Windows.Forms.Button buttonScaleMinus;
        private System.Windows.Forms.Label labelScale;
        private System.Windows.Forms.Button buttonRotateZPlus;
        private System.Windows.Forms.Button buttonRotateYMinus;
        private System.Windows.Forms.Button buttonRotateYPlus;
        private System.Windows.Forms.Button buttonRotateXMinus;
        private System.Windows.Forms.Button buttonRotateXPlus;
        private System.Windows.Forms.Button buttonRotateZMinus;
        private System.Windows.Forms.Label labelRotateZ;
        private System.Windows.Forms.Label labelRotateY;
        private System.Windows.Forms.Label labelRotateX;
        private System.Windows.Forms.TextBox textBoxNodeCOunt;
        private System.Windows.Forms.TextBox textBoxIsNormCount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Z;
        private System.Windows.Forms.ComboBox comboBoxChooseNode;
        private System.Windows.Forms.Button buttonTexture;
        private System.Windows.Forms.Button buttonColorfulQuads;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
    }
}

