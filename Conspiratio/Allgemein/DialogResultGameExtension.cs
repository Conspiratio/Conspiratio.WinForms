using System;
using System.Windows.Forms;

using Conspiratio.Lib.Allgemein;

namespace Conspiratio.Allgemein
{
    public static class DialogResultExtension
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="dialogResult"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static DialogResultGame ToDialogResultGame(this DialogResult dialogResult)
        {
            switch (dialogResult)
            {
                case DialogResult.None:
                    return DialogResultGame.None;
                case DialogResult.OK:
                    return DialogResultGame.OK;
                case DialogResult.Cancel:
                    return DialogResultGame.Cancel;
                case DialogResult.Abort:
                    return DialogResultGame.Abort;
                case DialogResult.Retry:
                    return DialogResultGame.Retry;
                case DialogResult.Ignore:
                    return DialogResultGame.Ignore;
                case DialogResult.Yes:
                    return DialogResultGame.Yes;
                case DialogResult.No:
                    return DialogResultGame.No;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dialogResult), dialogResult, "The given value is not supported for DialogResultGame.");
            }
        }
    }
}
