using java.io;
using System;
using System.IO;
using tr.gov.tubitak.uekae.esya.api.common.util;

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
                var lisansFilePath = currentDirectory + "\\lisansFree.xml";
                LicenseUtil.setLicenseXml(new ByteArrayInputStream(System.IO.File.ReadAllBytes(lisansFilePath)));
                freeLicenseLoaded = true;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
