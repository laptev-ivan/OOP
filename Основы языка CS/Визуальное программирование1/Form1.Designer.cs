
namespace Визуальное_программирование1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.kosSash = new System.Windows.Forms.RadioButton();
            this.maxSash = new System.Windows.Forms.RadioButton();
            this.arshin = new System.Windows.Forms.RadioButton();
            this.foot = new System.Windows.Forms.RadioButton();
            this.step = new System.Windows.Forms.RadioButton();
            this.lokot = new System.Windows.Forms.RadioButton();
            this.hand = new System.Windows.Forms.RadioButton();
            this.pad = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Метры:";
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(96, 27);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(116, 22);
            this.tb1.TabIndex = 1;
            // 
            // kosSash
            // 
            this.kosSash.AutoSize = true;
            this.kosSash.Location = new System.Drawing.Point(45, 84);
            this.kosSash.Name = "kosSash";
            this.kosSash.Size = new System.Drawing.Size(104, 18);
            this.kosSash.TabIndex = 2;
            this.kosSash.TabStop = true;
            this.kosSash.Text = "Косая сажень";
            this.kosSash.UseVisualStyleBackColor = true;
            // 
            // maxSash
            // 
            this.maxSash.AutoSize = true;
            this.maxSash.Location = new System.Drawing.Point(164, 84);
            this.maxSash.Name = "maxSash";
            this.maxSash.Size = new System.Drawing.Size(118, 18);
            this.maxSash.TabIndex = 3;
            this.maxSash.TabStop = true;
            this.maxSash.Text = "Маховая сажень";
            this.maxSash.UseVisualStyleBackColor = true;
            // 
            // arshin
            // 
            this.arshin.AutoSize = true;
            this.arshin.Location = new System.Drawing.Point(303, 84);
            this.arshin.Name = "arshin";
            this.arshin.Size = new System.Drawing.Size(62, 18);
            this.arshin.TabIndex = 4;
            this.arshin.TabStop = true;
            this.arshin.Text = "Аршин";
            this.arshin.UseVisualStyleBackColor = true;
            // 
            // foot
            // 
            this.foot.AutoSize = true;
            this.foot.Location = new System.Drawing.Point(403, 84);
            this.foot.Name = "foot";
            this.foot.Size = new System.Drawing.Size(47, 18);
            this.foot.TabIndex = 5;
            this.foot.TabStop = true;
            this.foot.Text = "Фут";
            this.foot.UseVisualStyleBackColor = true;
            // 
            // step
            // 
            this.step.AutoSize = true;
            this.step.Location = new System.Drawing.Point(45, 129);
            this.step.Name = "step";
            this.step.Size = new System.Drawing.Size(46, 18);
            this.step.TabIndex = 6;
            this.step.TabStop = true;
            this.step.Text = "Шаг";
            this.step.UseVisualStyleBackColor = true;
            // 
            // lokot
            // 
            this.lokot.AutoSize = true;
            this.lokot.Location = new System.Drawing.Point(164, 129);
            this.lokot.Name = "lokot";
            this.lokot.Size = new System.Drawing.Size(65, 18);
            this.lokot.TabIndex = 7;
            this.lokot.TabStop = true;
            this.lokot.Text = "Локоть";
            this.lokot.UseVisualStyleBackColor = true;
            // 
            // hand
            // 
            this.hand.AutoSize = true;
            this.hand.Location = new System.Drawing.Point(303, 129);
            this.hand.Name = "hand";
            this.hand.Size = new System.Drawing.Size(66, 18);
            this.hand.TabIndex = 8;
            this.hand.TabStop = true;
            this.hand.Text = "Ладонь";
            this.hand.UseVisualStyleBackColor = true;
            // 
            // pad
            // 
            this.pad.AutoSize = true;
            this.pad.Location = new System.Drawing.Point(397, 129);
            this.pad.Name = "pad";
            this.pad.Size = new System.Drawing.Size(53, 18);
            this.pad.TabIndex = 9;
            this.pad.TabStop = true;
            this.pad.Text = "Пядь";
            this.pad.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(267, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Перевести";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb2
            // 
            this.tb2.Location = new System.Drawing.Point(164, 167);
            this.tb2.Name = "tb2";
            this.tb2.ReadOnly = true;
            this.tb2.Size = new System.Drawing.Size(165, 22);
            this.tb2.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 227);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pad);
            this.Controls.Add(this.hand);
            this.Controls.Add(this.lokot);
            this.Controls.Add(this.step);
            this.Controls.Add(this.foot);
            this.Controls.Add(this.arshin);
            this.Controls.Add(this.maxSash);
            this.Controls.Add(this.kosSash);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Старинная русская система мер";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.RadioButton kosSash;
        private System.Windows.Forms.RadioButton maxSash;
        private System.Windows.Forms.RadioButton arshin;
        private System.Windows.Forms.RadioButton foot;
        private System.Windows.Forms.RadioButton step;
        private System.Windows.Forms.RadioButton lokot;
        private System.Windows.Forms.RadioButton hand;
        private System.Windows.Forms.RadioButton pad;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb2;
    }
}

