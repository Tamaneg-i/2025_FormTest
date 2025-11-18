using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Test
{

    /// 一つのマスをon/offにするやつ
    /// Buttonを読んで、on／offの状態とクリックしたときの反応を見る
    public class TestButton : Button
    {
        // 上on・下offの色
        private Color _onColor = Color.Orange;
        private Color _offColor = Color.White;

        // onの場合（true = 点灯）
        private bool _isOn;
        private Form1 _form1;
        //ボタンの位置
        private int _x;
        private int _y;
        public bool IsOn => _isOn;


        // ボタン座標やサイズ、推した時の動き方
        public TestButton(Form1 form1, int x, int y, Size size)
        {
            _form1 = form1;
            _x = x;
            _y = y;

          // ボタンの位置
            Location = new Point(x * size.Width, y * size.Height);
            Size = size;

            // ボタン推した時のやつ
            Click += ClickEvent;

            // 最初はオフにする（false）
            SetEnable(false);
        }

        // ライトの状態を指定して更新する。
        public void SetEnable(bool on)
        {
            // 色をかえる
            _isOn = on;
            BackColor = on ? _onColor : _offColor;
            
        }
        //　on/offの変更
        public void Toggle()
        {
            SetEnable(!_isOn);
        }
        // ボタンがクリックされたときの処理。
        // 自分と上下左右のボタンをかえる
        
        private void ClickEvent(object sender, EventArgs e)
        {
            _form1.GetTestButton(_x, _y)?.Toggle();       // おしたとこ
            _form1.GetTestButton(_x + 1, _y)?.Toggle();   // 右
            _form1.GetTestButton(_x - 1, _y)?.Toggle();   // 左
            _form1.GetTestButton(_x, _y + 1)?.Toggle();   // 下
            _form1.GetTestButton(_x, _y - 1)?.Toggle();   // 上

            // クリアしたかどうか
            _form1.CheckWin();
        }
    }
}

