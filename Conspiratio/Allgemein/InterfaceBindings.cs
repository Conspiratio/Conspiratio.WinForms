using Conspiratio.Lib.Allgemein;
using Conspiratio.Lib.Gameplay.Justiz;
using Conspiratio.Lib.Gameplay.Privilegien;
using Conspiratio.Lib.Gameplay.Spielwelt;
using Conspiratio.Privilegien;

namespace Conspiratio.Allgemein
{
    public class InterfaceBindings
    {
        public IStrafe[] GetStrafen()
        {
            var strafarten = new IStrafe[SW.Statisch.GetMaxAnzahlStrafen()];

            strafarten[0] = new StrafePranger();
            strafarten[1] = new StrafeKerker();
            strafarten[2] = new StrafeGeldstrafe();
            strafarten[3] = new StrafeAmtsenthebung();

            return strafarten;
        }

        public IPrivileg[] GetPrivilegien()
        {
            var privilegien = new IPrivileg[SW.Statisch.GetMaxPriv()];

            privilegien[1] = new PrivMedikus();
            privilegien[2] = new PrivAmtNiederlegen();
            privilegien[3] = new PrivTestament();
            privilegien[4] = new PrivRohstoffrecht();
            privilegien[5] = new PrivEinkommen();
            privilegien[6] = new PrivUntergebene();
            privilegien[7] = new PrivKerkerklatsch();
            privilegien[8] = new PrivConfessio();
            privilegien[9] = new PrivProzessInitiieren();
            privilegien[10] = new PrivBauwerkStiften();
            privilegien[11] = new PrivHaendler();
            privilegien[12] = new PrivKaufmann();
            privilegien[13] = new PrivGroßkaufmann();
            privilegien[14] = new PrivUmsatzsteuerFestlegen();
            privilegien[15] = new PrivSparplan();
            privilegien[16] = new PrivKeinKirchenzehnt();
            privilegien[17] = new PrivVergifteterWein();
            privilegien[18] = new PrivWachen();
            privilegien[19] = new PrivLeibgarde();
            privilegien[20] = new PrivHenkersHand();
            privilegien[21] = new PrivKorruptionsgelder();
            privilegien[22] = new PrivSchmuggel();
            privilegien[23] = new PrivZollkartell();
            privilegien[24] = new PrivKirGesetzeAendern();
            privilegien[25] = new PrivFinGesetzeAendern();
            privilegien[26] = new PrivStrafGesetzeAendern();
            privilegien[27] = new PrivSteuerhinterziehungA();
            privilegien[28] = new PrivSteuerhinterziehungB();
            privilegien[29] = new PrivSteuerhinterziehungC();
            privilegien[30] = new PrivGuenstigeKredite();
            privilegien[31] = new PrivZollfrei();
            privilegien[32] = new PrivPrediger();
            privilegien[33] = new PrivFestGeben();
            privilegien[34] = new PrivJurist();

            return privilegien;
        }

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
