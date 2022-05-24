using OpenQA.Selenium;

namespace SeleniumAutomation
{
    public static class SendKeyStepExecutorExtensions
    {
        public static string ToSeleniumKey(this ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.Help:
                    return Keys.Help;
                case ConsoleKey.Backspace:
                    return Keys.Backspace;
                case ConsoleKey.Tab:
                    return Keys.Tab;
                case ConsoleKey.Clear:
                    return Keys.Clear;
                case ConsoleKey.Enter:
                    return Keys.Enter;
                case ConsoleKey.Pause:
                    return Keys.Pause;
                case ConsoleKey.Escape:
                    return Keys.Escape;
                case ConsoleKey.Spacebar:
                    return Keys.Space;
                case ConsoleKey.PageUp:
                    return Keys.PageUp;
                case ConsoleKey.PageDown:
                    return Keys.PageDown;
                case ConsoleKey.End:
                    return Keys.End;
                case ConsoleKey.Home:
                    return Keys.Home;
                case ConsoleKey.LeftArrow:
                    return Keys.Left;
                case ConsoleKey.RightArrow:
                    return Keys.Right;
                case ConsoleKey.UpArrow:
                    return Keys.Up;
                case ConsoleKey.DownArrow:
                    return Keys.Down;
                case ConsoleKey.Insert:
                    return Keys.Insert;
                case ConsoleKey.Delete:
                    return Keys.Delete;
                case ConsoleKey.NumPad0:
                    return Keys.NumberPad0;
                case ConsoleKey.NumPad1:
                    return Keys.NumberPad1;
                case ConsoleKey.NumPad2:
                    return Keys.NumberPad2;
                case ConsoleKey.NumPad3:
                    return Keys.NumberPad3;
                case ConsoleKey.NumPad4:
                    return Keys.NumberPad4;
                case ConsoleKey.NumPad5:
                    return Keys.NumberPad5;
                case ConsoleKey.NumPad6:
                    return Keys.NumberPad6;
                case ConsoleKey.NumPad7:
                    return Keys.NumberPad7;
                case ConsoleKey.NumPad8:
                    return Keys.NumberPad8;
                case ConsoleKey.NumPad9:
                    return Keys.NumberPad9;
                case ConsoleKey.Multiply:
                    return Keys.Multiply;
                case ConsoleKey.Divide:
                    return Keys.Divide;
                case ConsoleKey.Add:
                    return Keys.Add;
                case ConsoleKey.Subtract:
                    return Keys.Subtract;
                case ConsoleKey.Separator:
                    return Keys.Separator;
                case ConsoleKey.Decimal:
                    return Keys.Decimal;
                case ConsoleKey.F1:
                    return Keys.F1;
                case ConsoleKey.F2:
                    return Keys.F2;
                case ConsoleKey.F3:
                    return Keys.F3;
                case ConsoleKey.F4:
                    return Keys.F4;
                case ConsoleKey.F5:
                    return Keys.F5;
                case ConsoleKey.F6:
                    return Keys.F6;
                case ConsoleKey.F7:
                    return Keys.F7;
                case ConsoleKey.F8:
                    return Keys.F8;
                case ConsoleKey.F9:
                    return Keys.F9;
                case ConsoleKey.F10:
                    return Keys.F10;
                case ConsoleKey.F11:
                    return Keys.F11;
                case ConsoleKey.F12:
                    return Keys.F12;
                case ConsoleKey.LeftWindows:
                    return Keys.Meta;
                default: return Keys.Enter;
            }
        }
    }
}
