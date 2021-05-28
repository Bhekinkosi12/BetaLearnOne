using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BetaLearnOne.Models.DocumentModel;
using Plugin.XamarinFormsSaveOpenPDFPackage;

namespace BetaLearnOne.Services.DocumentData
{
   public class DocumentDataStore
    {

        List<DocumentM> DocumentsPhysics { get; set; }


        public DocumentDataStore()
        {
            setData();
        }

      


        private void setData()
        {
            DocumentsPhysics = new List<DocumentM>()
            {
                new DocumentM
                {
                     ID = Guid.NewGuid().ToString(),
                     Topic = "Momentum and impulse",
                     PdfDocument = "PhysicalSciencesG12.pdf",
                     StartPage = 30,
                     
                    

                },
                new DocumentM
                {
                    ID = Guid.NewGuid().ToString(),
                    Topic = "Vertical projectile motion",
                    PdfDocument = "PhysicalSciencesG12.pdf",
                    StartPage = 82
                }

            };

        }


        public DocumentM ReturnOneDocument()
        {
           return DocumentsPhysics[1];
        }
    }
}
