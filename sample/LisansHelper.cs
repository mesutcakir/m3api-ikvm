using java.io;
using System;
using System.IO;
using tr.gov.tubitak.uekae.esya.api.common.util;
using tr.gov.tubitak.uekae.esya.api.smartcard.pkcs11;

namespace SignPdfSample
{
    public class LisansHelper
    {
        private static bool freeLicenseLoaded;
        public static bool LoadFreeLicense()
        {
            try
            {
                if (freeLicenseLoaded)
                    return true;
                var currentDirectory = Directory.GetCurrentDirectory();
                var lisansFilePath = Path.Combine(currentDirectory, "lisansFree.xml");
                System.Console.WriteLine("lisansFilePath: " + lisansFilePath);
                LicenseUtil.setLicenseXml(new ByteArrayInputStream(System.IO.File.ReadAllBytes(lisansFilePath)));
                freeLicenseLoaded = true;

                #region ControlTypes


                long slotNum = -1;
                CardType ismCard = null;
                CardType[] myCards = tr.gov.tubitak.uekae.esya.api.smartcard.pkcs11.CardType.getCardTypes();
                foreach (CardType c in myCards)
                {
                    try
                    {
                        slotNum = SmartOp.findSlotNumber(c);
                        if (slotNum != -1)
                        {
                            ismCard = c;
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(c.getName() + " - " + ex.Message);
                    }
                }
                #endregion


                return slotNum > -1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
