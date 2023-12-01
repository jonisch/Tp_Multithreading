﻿namespace TPMultiThreading
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnAddTrain = new System.Windows.Forms.Button();
            this.picMap = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numSpeed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableActiveTrains = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableActiveTrains.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddTrain
            // 
            this.btnAddTrain.Location = new System.Drawing.Point(76, 35);
            this.btnAddTrain.Name = "btnAddTrain";
            this.btnAddTrain.Size = new System.Drawing.Size(49, 23);
            this.btnAddTrain.TabIndex = 1;
            this.btnAddTrain.Text = "Add Train";
            this.btnAddTrain.UseVisualStyleBackColor = true;
            this.btnAddTrain.Click += new System.EventHandler(this.BtnAddTrain_Click);
            // 
            // picMap
            // 
            this.picMap.Dock = System.Windows.Forms.DockStyle.Top;
            this.picMap.Image = ((System.Drawing.Image)(resources.GetObject("picMap.Image")));
            this.picMap.Location = new System.Drawing.Point(0, 0);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(1269, 339);
            this.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMap.TabIndex = 3;
            this.picMap.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 345);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 109);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nuevo Tren";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.numSpeed, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddTrain, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(211, 84);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // numSpeed
            // 
            this.numSpeed.Location = new System.Drawing.Point(76, 3);
            this.numSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSpeed.Name = "numSpeed";
            this.numSpeed.Size = new System.Drawing.Size(66, 26);
            this.numSpeed.TabIndex = 1;
            this.numSpeed.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Velocidad";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableActiveTrains);
            this.groupBox2.Location = new System.Drawing.Point(15, 460);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1067, 155);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trenes Activos";
            // 
            // tableActiveTrains
            // 
            this.tableActiveTrains.AutoScroll = true;
            this.tableActiveTrains.ColumnCount = 4;
            this.tableActiveTrains.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableActiveTrains.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableActiveTrains.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableActiveTrains.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 601F));
            this.tableActiveTrains.Controls.Add(this.label5, 3, 0);
            this.tableActiveTrains.Controls.Add(this.label4, 1, 0);
            this.tableActiveTrains.Controls.Add(this.label3, 0, 0);
            this.tableActiveTrains.Controls.Add(this.label6, 2, 0);
            this.tableActiveTrains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableActiveTrains.Location = new System.Drawing.Point(3, 22);
            this.tableActiveTrains.Name = "tableActiveTrains";
            this.tableActiveTrains.RowCount = 2;
            this.tableActiveTrains.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableActiveTrains.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableActiveTrains.Size = new System.Drawing.Size(1061, 130);
            this.tableActiveTrains.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(463, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Estado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(63, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Estación Actual";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tren #";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(263, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "Destino";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 627);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picMap);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableActiveTrains.ResumeLayout(false);
            this.tableActiveTrains.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAddTrain;
        private System.Windows.Forms.PictureBox picMap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numSpeed;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableActiveTrains;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

