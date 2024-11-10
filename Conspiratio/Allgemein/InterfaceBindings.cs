using Conspiratio.Lib.Allgemein;
using Conspiratio.Lib.Gameplay.Privilegien;
using Conspiratio.Privilegien;

namespace Conspiratio.Allgemein
{
    public class InterfaceBindings
    {
        public IJaNeinFrage GetJaNeinFrage()
        {
            return new JaNeinFrage();
        }

        public ITextAnzeigen GetTextAnzeigen()
        {
            return new Textanzeigen();
        }

        public IBeziehungPflegen GetBeziehungPflegen()
        {
            return new BeziehungenPflegen();
        }

        public IBauwerkStiftenDialog GetBauwerkStiftenDialog()
        {
            return new BauwerkStiftenForm();
        }

        public IFestGebenDialog GetFestGebenDialog()
        {
            return new frmFestGeben();
        }

        public IPolitischeWeltkarteDialog GetPolitischeWeltkarteDialog()
        {
            return new PolitischeWeltkarte();
        }

        public ITestamentAnzeigenDialog GetTestamentAnzeigenDialog()
        {
            return new Testamentanzeigen();
        }

        public IProzentwertFestlegenDialog GetProzentwertFestlegenDialog()
        {
            return new ProzentwertFestlegenForm();
        }

        public IUntergebeneDialog GetUntergebeneDialog()
        {
            return new UntergebeneForm();
        }
    }
}
