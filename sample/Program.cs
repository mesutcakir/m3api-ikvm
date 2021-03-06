﻿using java.io;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tr.gov.tubitak.uekae.esya.api.pades;
using tr.gov.tubitak.uekae.esya.api.signature;
using tr.gov.tubitak.uekae.esya.api.smartcard.pkcs11;

namespace SignPdfSample
{
    class Program
    {
        public static byte KartOkuyucuYok = 0;
        public static int TerminalSayisi = 0;
        public static string PinKodu;
        public static string HataMesaji = "";



        public static string SertifikaBilgisi = "";
        public static string CardType = "";

        public static string ParamCardType { get; internal set; }
        public static string ParamSlotId { get; internal set; }
        public static string Terminal { get; internal set; }
        public static bool ReadCard()
        {
            var smartCardManager = SmartCardManager.getInstance();

            if (Program.KartOkuyucuYok == 1) return false;

            var signingCert = smartCardManager.getSignatureCertificate(true, false);

            Program.SertifikaBilgisi = "Sertifika ve Sahiplik Bilgisi: " + signingCert;

            return true;
        }
        static void Main(string[] args)
        {
            if (LisansHelper.LoadFreeLicense())
            {
                SignPdf();
            }
            System.Console.ReadLine();
        }
        static void SignPdf()
        {
            if (ReadCard())
            {
                var smartCardManager = SmartCardManager.getInstance();
                var signingCert = smartCardManager.getSignatureCertificate(true, false);
                var baseSigner = smartCardManager.getSigner("199188", signingCert); // "12345"
                var bytes = System.IO.File.ReadAllBytes("test.pdf");
                using (var signedPdfStream = new ByteArrayOutputStream())
                {
                    using (var inputStream = new ByteArrayInputStream(bytes))
                    {
                        //JAVA VERSİYON
                        var signatureContext = new PAdESContext(new java.net.URI(""), new tr.gov.tubitak.uekae.esya.api.signature.config.Config("esya-signature-config.xml"));
                        SignatureContainer pc = SignatureFactory.readContainer(SignatureFormat.PAdES, inputStream, signatureContext);
                        Signature signature = pc.createSignature(signingCert);
                        signature.setSigningTime(java.util.Calendar.getInstance());
                        signature.sign(baseSigner);
                        pc.write(signedPdfStream);
                        System.IO.File.WriteAllBytes("test-signed.pdf", signedPdfStream.toByteArray());
                    }
                }
            }
        }
    }
}
