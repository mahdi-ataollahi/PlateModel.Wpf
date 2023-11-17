using Microsoft.Xaml.Behaviors;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace IRPlateModel.Wpf.Assets.Behaviors
{
    public class MaskedTextboxBehavior : Behavior<TextBox>
    {
        #region PredefinedPatterns Enum
        public enum PredefinedPatterns
        {
            None = 0,
            Digits,
            NonZeroDigits,
        }
        #endregion

        #region PredefinedPattern
        public static readonly DependencyProperty PredefinedPatternProperty =
            DependencyProperty.Register("PredefinedPattern",
                typeof(PredefinedPatterns),
                typeof(MaskedTextboxBehavior),
                new PropertyMetadata(PredefinedPatterns.None, (obj, e) =>
                {
                    if (e.NewValue != null)
                    {
                        var beh = obj as MaskedTextboxBehavior;
                        PredefinedPatterns pp = (PredefinedPatterns)e.NewValue;
                        string pattern = "";

                        switch (pp)
                        {
                            case PredefinedPatterns.Digits:
                                pattern = @"^\d*$";
                                break;
                            case PredefinedPatterns.NonZeroDigits:
                                pattern = @"^[1-9]*$";
                                break;
                        }

                        beh.RegularExpressionPattern = pattern;
                    }
                }));

        public PredefinedPatterns PredefinedPattern
        {
            get { return (PredefinedPatterns)GetValue(PredefinedPatternProperty); }
            set { SetValue(PredefinedPatternProperty, value); }
        }
        #endregion

        #region RegularExpressionPattern
        public static readonly DependencyProperty RegularExpressionPatternProperty =
            DependencyProperty.Register("RegularExpressionPattern",
                typeof(string),
                typeof(MaskedTextboxBehavior),
                new PropertyMetadata(""));

        public string RegularExpressionPattern
        {
            get { return (string)GetValue(RegularExpressionPatternProperty); }
            set { SetValue(RegularExpressionPatternProperty, value); }
        }
        #endregion

        #region RegexOptions
        public static readonly DependencyProperty RegexOptionsProperty =
            DependencyProperty.Register("RegexOptions",
                typeof(RegexOptions),
                typeof(MaskedTextboxBehavior),
                new PropertyMetadata(RegexOptions.None));

        public RegexOptions RegexOptions
        {
            get { return (RegexOptions)GetValue(RegexOptionsProperty); }
            set { SetValue(RegexOptionsProperty, value); }
        }
        #endregion

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.TextChanged += MaskedTextboxBehavior_TextChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.TextChanged -= MaskedTextboxBehavior_TextChanged;
        }

        private void MaskedTextboxBehavior_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.RegularExpressionPattern) == false)
            {
                var txt = sender as TextBox;
                string text = txt.Text;
                if (Regex.IsMatch(text, this.RegularExpressionPattern, this.RegexOptions) == false)
                {
                    int index = txt.SelectionStart;
                    string s = "";
                    if (txt.SelectionStart > 0)
                    {
                        s = text.Substring(0, txt.SelectionStart - 1);
                        index = txt.SelectionStart - 1;
                    }
                    s += text.Substring(txt.SelectionStart);
                    txt.Text = s;
                    txt.SelectionStart = index;
                }
            }
        }

    }
}
