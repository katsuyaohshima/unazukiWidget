using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnazukiWidget
{
    public partial class widget : Form
    {
        int state = 0;//! < 0=初期化ステート、1=初期化待機ステート、2=表示ステート
        double InitializeTime = 1;//! < widgetの初期化待機時間(x10msec)
        double DisplayTime = 10;  //! < widgetの表示時間(x10msec)
        int screen_height = Screen.PrimaryScreen.WorkingArea.Height; //! < スクリーンの作業領域の高さを取得
        int screen_width = Screen.PrimaryScreen.WorkingArea.Width; //! < スクリーンの作業領域の幅を取得
        bool initialize = false;

        public widget()
        {
            
            InitializeComponent();
            //! * タイマー起動
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //! * 初期化ステート
            //!     * ウィンドウの位置決めをする。
            if (state == 0)
            {
                this.Top = screen_height - this.Height;
                this.Left = screen_width - this.Width - 30;
                this.Opacity = 0;
                state++;
            }

            //! * 初期化待機ステート
            //!     * 待機時間減らす
            //!     * 待機時間が経過したらOpacityを1にして表示モードにする。（誤表示の回避）
            else if (state == 1) {

                InitializeTime -= 0.1;
                if (InitializeTime <= 0) {
                    this.Opacity = 1;
                    state++;
                }
            }
            
            //! * 表示ステート
            //!     * 表示時間減らす
            //!     * 最後の10msecはWidgetを透過&移動させながらかっこよく消す。
            //!     * 表示時間が0になったらアプリを終了する。
            else
            {

                DisplayTime -= 0.1;
                if (DisplayTime < 1)
                {
                    this.Opacity = DisplayTime;
                    this.Top = this.Top + 1;
                }
                if (DisplayTime <= 0)
                {
                    Application.Exit();
                }
            }
        }
    }
}
