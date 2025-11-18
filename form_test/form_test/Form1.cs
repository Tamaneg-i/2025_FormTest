using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Test
{
    /// <summary>
    ///　フォームを管理するところ
    /// </summary>
    public partial class Form1 : Form
    {
        // ボタンのサイズ
        const int BUTTON_SIZE = 100;

        // 盤面サイズ
        const int BOARD_SIZE = 3;

        // ボタンを格納するやつ
        private TestButton[,] _buttonArray;

        // 初期配置のランダム化
        private Random _rand = new Random();

        /// <summary>
        /// フォームの初期化
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            _buttonArray = new TestButton[BOARD_SIZE, BOARD_SIZE];

            // ボタンを配置
            for (int y = 0; y < BOARD_SIZE; y++)
            {
                for (int x = 0; x < BOARD_SIZE; x++)
                {
                    // TestButtonを作ってフォームに送る
                    var btn = new TestButton(
                        this,
                        x, y,
                        new Size(BUTTON_SIZE, BUTTON_SIZE)
                    );

                    _buttonArray[y, x] = btn;
                    Controls.Add(btn);
                }
            }

            // 開始したときにランダムでon/off
            RandomizeBoard();
        }

        // おしたところをなんかする
        // 範囲外のときはnullを返す
        public TestButton GetTestButton(int x, int y)
        {
            if (x < 0 || y < 0 || x >= BOARD_SIZE || y >= BOARD_SIZE)
                return null;

            return _buttonArray[y, x];
        }

        //全てのボタンがONまたはOFFになっているかを判定。
        // クリア状態ならメッセージを表示して再スタート。
        public void CheckWin()
        {
            bool allOn = true;
            bool allOff = true;

            foreach (var b in _buttonArray)
            {
                if (b.IsOn) allOff = false;  // 1つでもONがあればだめ
                else allOn = false;          // 1つでもOFFがあればだめ
            }

            // 全てONまたは全てOFFのとき
            if (allOn || allOff)
            {
                MessageBox.Show("成功");
                RandomizeBoard(); // 次のランダム盤面へ
            }
        }
        // 各ボタンをランダムにON/OFFする
        private void RandomizeBoard()
        {
            foreach (var b in _buttonArray)
            {
                bool randomState = _rand.Next(2) == 0;
                b.SetEnable(randomState);
            }
        }
    }
}


