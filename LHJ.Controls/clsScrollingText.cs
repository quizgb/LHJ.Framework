using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace clsScrollingText
{
    /// <summary>
    /// Summary description for DougScrollingTextCtrl.
    /// </summary>
    
    /*//////////////////////////////////////////////////////////////////////////////
    //
    // Function: class DougScrollingTextCtrl.
    //
    // By: Doug 
    //
    // Date: 2/27/03
    //
    // Description: Create the control and derive it from System.Windows.Forms.Control.
    //
    /////////////////////////////////////////////////////////////////////////////*/ 
    //
    public class DougScrollingTextCtrl : System.Windows.Forms.Control
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private Color m_Color1 = Color.Black;  // First default color.
        private Color m_Color2 = Color.Gold;   // Second default color.
        private Font m_MyFont;   // For the font.

        protected Timer m_Timer;             // Timer for text animation.
        protected string sScrollText = null;   // Text to be displayed in the control.
        
        /// <summary>
        /// Add member variables.
        /// </summary>

        /*//////////////////////////////////////////////////////////////////////////////
        //
        // Function: public DougScrollingTextCtrl()
        //
        // By: Doug 
        //
        // Date: 2/27/03
        //
        // Description: Constructor.
        //
        /////////////////////////////////////////////////////////////////////////////*/ 
        //
        public DougScrollingTextCtrl()
        {
            m_Timer = new Timer();

            // Set the timer speed and properties.
            m_Timer.Interval = 250;
            m_Timer.Enabled = true;
            m_Timer.Tick += new EventHandler( Animate );
        }

        public int Delay
        {
            get { return m_Timer.Interval; }
            set
            {
                m_Timer.Interval = value;
            }
        }

        // Add a color property.
        public Color DougScrollingTextColor1
        {
            get { return m_Color1; }
            set 
            {
                m_Color1 = value; 
                Invalidate();
            }
        }

        // Add a color property.
        public Color DougScrollingTextColor2
        {
            get { return m_Color2; }
            set 
            {
                m_Color2 = value; 
                Invalidate();
            }
        }

        /*//////////////////////////////////////////////////////////////////////////////
        //
        // Function: Animate( object sender, EventArgs e )
        //
        // By: Doug 
        //
        // Date: 2/27/03
        //
        // Description: Sets up the animation of the text.
        //
        /////////////////////////////////////////////////////////////////////////////*/ 
        //
        void Animate( object sender, EventArgs e )
        {
            // sScrollText string is from the Text property, add 4 spaces after the string so everything is not bunche together.
            if( sScrollText == null )
            {
                sScrollText = Text + "    ";
            }

            // Scroll text by triming one character at a time from the left, then adding that character to the right side of the control to make it look like scrolling text.
            sScrollText = sScrollText.Substring( 1, sScrollText.Length-1 ) + sScrollText.Substring(
 0, 1 );
            
            // Call Invalidate() to tell the windows form that our control needs to be repainted.
            Invalidate();
        }

        /*//////////////////////////////////////////////////////////////////////////////
        //
        // Function: StartStop( object sender, EventArgs e )
        //
        // By: Doug 
        //
        // Date: 2/27/03
        //
        // Description: Start and stop the timer.
        //
        /////////////////////////////////////////////////////////////////////////////*/ 
        //
        void StartStop( object sender, EventArgs e )
        {
            m_Timer.Enabled = !m_Timer.Enabled;
        }

        /*//////////////////////////////////////////////////////////////////////////////
        //
        // Function: protected override void OnTextChanged( EventArgs e )
        //
        // By: Doug 
        //
        // Date: 2/27/03
        //
        // Description: If/when the string text is changed, I need to update the sScrollText string.
        //
        /////////////////////////////////////////////////////////////////////////////*/ 
        //
        protected override void OnTextChanged( EventArgs e )
        {
            sScrollText = null;

            base.OnTextChanged( e );
        }

        /*//////////////////////////////////////////////////////////////////////////////
        //
        // Function: protected override void OnClick( EventArgs e )
        //
        // By: Doug 
        //
        // Date: 2/27/03
        //
        // Description: Handle the click event of the DougScrollingTextCtrl.
        //
        /////////////////////////////////////////////////////////////////////////////*/ 
        //
        protected override void OnClick( EventArgs e )
        {
            m_Timer.Enabled = !m_Timer.Enabled;

            base.OnClick( e );
        }

        /*public override void Dispose()
        {
            // Since the m_Timer hasn't been added to a collection (because
            // we don’t have one!) we have to dispose it manually.
            m_Timer.Dispose();
            base.Dispose();
        }*/

        /*//////////////////////////////////////////////////////////////////////////////
        //
        // Function: protected override void OnPaint( PaintEventArgs pe )
        //
        // By: Doug 
        //
        // Date: 2/27/03
        //
        // Description: Paint the DougScrollingTextCtrl.
        //
        /////////////////////////////////////////////////////////////////////////////*/ 
        //
        protected override void OnPaint( PaintEventArgs pe )
        {
            // This is a fancy brush that draws graded colors.
            Brush MyBrush = new System.Drawing.Drawing2D.LinearGradientBrush( ClientRectangle, m_Color1, m_Color2, 10 );

            // Get the font and use it to draw text in the control.  Resize to the height of the control if possible.
            m_MyFont = new Font( Font.Name, (Height*3)/4, Font.Style, GraphicsUnit.Pixel );

            // Draw the text string in the control.
            pe.Graphics.DrawString( sScrollText, m_MyFont, MyBrush, 0, 0 );

            base.OnPaint (pe);

            // Clean up variables..
            MyBrush.Dispose(); 
            m_MyFont.Dispose();
        }
    }
}
