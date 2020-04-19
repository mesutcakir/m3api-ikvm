using tr.gov.tubitak.uekae.esya.api.smartcard.pkcs11;
namespace SignPdfSample
{
    public static class CardTypeConverter
    {
        public static CardType AsCardType(string cardtype)
        {
            switch (cardtype)
            {
                case "AEPKEYPER":
                    return CardType.AEPKEYPER;

                case "AKIS":
                    return CardType.AKIS;

                case "AKIS_KK":
                    return CardType.AKIS_KK;

                case "ALADDIN":
                    return CardType.ALADDIN;

                case "CARDOS":
                    return CardType.CARDOS;

                case "DATAKEY":
                    return CardType.DATAKEY;

                case "GEMPLUS":
                    return CardType.GEMPLUS;

                case "KEYCORP":
                    return CardType.KEYCORP;

                case "NCIPHER":
                    return CardType.NCIPHER;

                case "SAFESIGN":
                    return CardType.SAFESIGN;

                case "SEFIROT":
                    return CardType.SEFIROT;

                case "TKART":
                    return CardType.TKART;

                case "UNKNOWN":
                    return CardType.UNKNOWN;

                case "UTIMACO":
                    return CardType.UTIMACO;
            }
            return CardType.UNKNOWN;
        }
    }
}
