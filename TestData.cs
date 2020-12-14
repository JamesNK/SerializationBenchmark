using System;
using System.Collections.Generic;

namespace SerializationBenchmark
{
    internal static class TestData
    {
        public static readonly UserLicensesResponsePB TestValuePB;

        static TestData()
        {
            var r = new Random();
            foreach (var l in TestValue.Licenses)
            {
                foreach (var sp in l.ServicePlans)
                {
                    sp.Count = r.Next();
                }
            }

            var ulr = new UserLicensesResponsePB();

            // convert the test value from below into the protobuf types
            foreach (var ul in TestValue.Licenses)
            {
                var ulpb = new UserLicensePB();
                ulpb.ObjectId = ul.ObjectId;
                ulpb.SkuId = ul.SkuId;
                ulpb.SkuPartNumber = ul.SkuPartNumber;
                ulr.Licenses.Add(ulpb);

                foreach (var fc in ul.FruitColors)
                {
                    ulpb.FruitColors.Add(fc.Key, (ColorPB)fc.Value);
                }

                foreach (var sp in ul.ServicePlans)
                {
                    var sppb = new ServicePlanPB();
                    sppb.AppliesTo = sp.AppliesTo;
                    sppb.Count = sp.Count;
                    sppb.ServicePlanId = sp.ServicePlanId;
                    sppb.ServicePlanName = sp.ServicePlanName;

                    ulpb.SercucePlans.Add(sppb);
                }
            }

            TestValuePB = ulr;
        }

        // This is the data we use to serialize/deserialize in the benchmark
        public static readonly UserLicensesResponse TestValue = new UserLicensesResponse
        {
            Licenses = new UserLicense[]
            {
                new UserLicense{
                    ObjectId = "v4j5cvGGr0GRqy180BHbR2An38eBLPdOtXhbU5K1cd8",
                    SkuId = "c7df2760-2c81-4ef7-b578-5b5392b571df",
                    SkuPartNumber = "JDHDYIIWSDH&WDFD",
                    ServicePlans = new ServicePlan[]{
                        new ServicePlan{ ServicePlanName = "rier8gu9erg8we8uwe8euwe8f", ServicePlanId = "2f442157-a11c-46b9-ae5b-6e39ff4e5849", ProvisioningStatus = "Disabled", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "DKDIJFOIJEKMMKI_DJFUE", ServicePlanId = "c4801e8a-cb58-4c35-aca6-f2dcc106f287", ProvisioningStatus = "Disabled", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "URMMOOFLLOOOELLD", ServicePlanId = "0898bdbb-73b0-471a-81e5-20f1fe4dd66e", ProvisioningStatus = "Disabled", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "KFOKOKEFOKEFKKD", ServicePlanId = "94065c59-bc8e-4e8b-89e5-5138d471eaff", ProvisioningStatus = "PendingProvisioning", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "PREMIUM_ENCRYPTION", ServicePlanId = "617b097b-4b93-4ede-83de-5f075bb5fb2f", ProvisioningStatus = "Disabled", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "KORKOFJJ+FJUURKKKF", ServicePlanId = "4a51bca5-1eff-43f5-878c-177680f191af", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "MIP_S_CLP2", ServicePlanId = "efb0351d-3b08-4503-993d-383af8de41e3", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "MIP_S_CLP1", ServicePlanId = "5136a095-5cf0-4aff-bec3-e84448b38ea5", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "rOFKOPRKOKR", ServicePlanId = "33c4f319-9bdd-48d6-9c4d-410b750a4a5a", ProvisioningStatus = "Disabled", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "FK{ORoIMMopOSOF", ServicePlanId = "b1188c4c-1b36-4018-b48b-ee07604f6feb", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "JDOJOIJOINMDCOKE ", ServicePlanId = "3fb82609-8c27-4f7b-bd51-30634711ee67", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "FPOJRMVIONEVOINJI", ServicePlanId = "e212cbc7-0961-4c40-9825-01117710dcb1", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "ODKJMLE:OPU(EFMMFM", ServicePlanId = "6c6042f5-6f01-4d67-b8c1-eb99d36eed3e", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "DFPOFKOKEPFPJJFJJJE", ServicePlanId = "8e0c0a52-6a6c-4d40-8370-dd62790dcd70", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "FIUEINNFUUU B  DJDJ", ServicePlanId = "8c7d2df8-86f0-4902-b2ed-a0458298f3b3", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "DOJIHOWJNJNJNMJJF", ServicePlanId = "07699545-9485-468e-95b6-2fca3738be01", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "DPOIOIRKLMK:MF", ServicePlanId = "9c0dab89-a30c-4117-86e7-97bda240acd2", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "FOKIOROFJPKRMKMERG", ServicePlanId = "57ff2da0-773e-42df-b2af-ffb7a2317929", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "IOJIOREJNERKNGKNRG", ServicePlanId = "8c098270-9dd4-4350-9b30-ba4703f3b36b", ProvisioningStatus = "PendingInput", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "RiJGIOERJMNERGJERGJ", ServicePlanId = "4de31727-a228-4ec3-a5bf-8e45b5ca48cc", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "RIGJOIERJG ERGUJERNG HRG", ServicePlanId = "9f431833-0334-42de-a7dc-70aa40db46db", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = ":LKLKFJIDINIOJO OI OD FDFO ", ServicePlanId = "34c0d7a0-a70f-4668-9238-47f9fc208882", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "DOKFK", ServicePlanId = "a23b959c-7ce8-4e57-9140-b90eb88a9e97", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "DKJKJDIFJMD OOEDF WEF ", ServicePlanId = "f20fedf3-f3c3-43c3-8267-2bfdd51c0939", ProvisioningStatus = "PendingProvisioning", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "DOKOIO(F", ServicePlanId = "4828c8ec-dc2e-4779-b502-87ac9ce28ab7", ProvisioningStatus = "Disabled", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "FLKFOKOPKLMF", ServicePlanId = "3e26ee1f-8a5f-4d52-aee2-b81ce45c8f40", ProvisioningStatus = "Disabled", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "DFOKOEKFOKL<DLV ", ServicePlanId = "70d33638-9c74-4d01-bfd3-562de28bd4ba", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "DOOPDPOFI", ServicePlanId = "882e1d05-acd1-4ccb-8708-6ee03664b117", ProvisioningStatus = "PendingActivation", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "SDKJFPOJFJIEJFWEF", ServicePlanId = "b737dad2-2f6c-4c65-90e3-ca563267e8b9", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "SDL:K:LDSKOKPOKSDPFKOSKDF", ServicePlanId = "bea4c11e-220a-4e6d-8eb8-8ea15d019f90", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "GPKLGPOKOPFKPFP F", ServicePlanId = "7547a3fe-08ee-4ccb-b430-5077c5041653", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "FGLKPRKgpOKERGPOK", ServicePlanId = "43de0ff5-c92c-492b-9116-175376d08c38", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "WE;lfk:LWKF:LKW", ServicePlanId = "0feaeb32-d00e-4d66-bd5a-43b5b83db82c", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "RJIEJOIJGOJER", ServicePlanId = "efb87545-963c-4e0d-99df-69c6916d9eb0", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "GKROPKGPOKERKGPOKERG", ServicePlanId = "5dbe027f-2339-4123-9542-606e4d348a72", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "RIJIERJGOIJERG", ServicePlanId = "e95bec33-7c88-4a70-8e19-b10bd9d0c014", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                    },
                    FruitColors = new Dictionary<string, Color>
                    {
                        { "Banana", Color.Yellow },
                        { "Orange", Color.Orange },
                        { "Apple", Color.Red },
                        { "Lemon", Color.Yellow },
                    },
                },
                new UserLicense{
                    ObjectId = "v4j5cvGGr0GRqy180BHbR_iz2JAucXtPqh5i565svpY",
                    SkuId = "90d8b3f8-712e-4f7b-aa1e-62e7ae6cbe96",
                    SkuPartNumber = "ROKPOKRPOGKR",
                    ServicePlans = new ServicePlan[]{
                        new ServicePlan{ ServicePlanName = "KJOIERJOJERG", ServicePlanId = "39b5c996-467e-4e60-bd62-46066f572726", ProvisioningStatus = "Disabled", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "ER:LKERKGERGKPOKEROGKERG", ServicePlanId = "199a5c09-e0ca-4e37-8f7c-b05d533e1ea2", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                    },
                    FruitColors = new Dictionary<string, Color>
                    {
                        { "Banana", Color.Yellow },
                        { "Orange", Color.Orange },
                        { "Apple", Color.Red },
                        { "Lemon", Color.Yellow },
                    },
                },
                new UserLicense{
                    ObjectId = "v4j5cvGGr0GRqy180BHbR4EkbAOKqs1Hq0MyTwwVfC0",
                    SkuId = "036c2481-aa8a-47cd-ab43-324f0c157c2d",
                    SkuPartNumber = "OKRPOKPKOER",
                    ServicePlans = new ServicePlan[]{
                        new ServicePlan{ ServicePlanName = "ERKERKPGKERGK", ServicePlanId = "ed8e8769-94c5-4132-a3e7-7543b713d51f", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                    },
                    FruitColors = new Dictionary<string, Color>
                    {
                        { "Banana", Color.Yellow },
                        { "Orange", Color.Orange },
                        { "Apple", Color.Red },
                        { "Lemon", Color.Yellow },
                    },
                },
                new UserLicense{
                    ObjectId = "v4j5cvGGr0GRqy180BHbR59fAQl_NzhFu7X3XOsJNYo",
                    SkuId = "09015f9f-377f-4538-bbb5-f75ceb09358a",
                    SkuPartNumber = "RKEORGKPOERKG",
                    ServicePlans = new ServicePlan[]{
                        new ServicePlan{ ServicePlanName = "ERKPOKERGPKEPRGKPOEKRG", ServicePlanId = "818523f5-016b-4355-9be8-ed6944946ea7", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "ERMKKERGOOJojERGJ", ServicePlanId = "fa200448-008c-4acb-abd4-ea106ed2199d", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "RELKGPOEKRGPKEPRGKPER", ServicePlanId = "50554c47-71d9-49fd-bc54-42a2765c555c", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "RGPEKRJGOKEPRMGPERMPGOK", ServicePlanId = "113feb6c-3fe4-4440-bddc-54d774bf0318", ProvisioningStatus = "PendingProvisioning", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "WFJOWIJFOIWJFOIJWF", ServicePlanId = "e95bec33-7c88-4a70-8e19-b10bd9d0c014", ProvisioningStatus = "Disabled", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "WEFPOKWPEKFPOWKEFPOKWEPOFK", ServicePlanId = "fe71d6c3-a2ea-4499-9778-da042bf08063", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "WOEFKOPWEFKPOWKEFPOK", ServicePlanId = "5dbe027f-2339-4123-9542-606e4d348a72", ProvisioningStatus = "Disabled", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "WOEKFOKWEPOFKPOWKEF", ServicePlanId = "fafd7243-e5c1-4a3a-9e40-495efcb1d3c3", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                    },
                    FruitColors = new Dictionary<string, Color>
                    {
                        { "Banana", Color.Yellow },
                        { "Orange", Color.Orange },
                        { "Apple", Color.Red },
                        { "Lemon", Color.Yellow },
                    },
                },
                new UserLicense{
                    ObjectId = "v4j5cvGGr0GRqy180BHbR6xtlLx3eHFCsveZ0tsTzSw",
                    SkuId = "bc946dac-7877-4271-b2f7-99d2db13cd2c",
                    SkuPartNumber = "eererferferg",
                    ServicePlans = new ServicePlan[]{
                        new ServicePlan{ ServicePlanName = "ergergergerg", ServicePlanId = "17efdd9f-c22c-4ad8-b48e-3b1f3ee1dc9a", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "ergergergergergergerg", ServicePlanId = "e212cbc7-0961-4c40-9825-01117710dcb1", ProvisioningStatus = "Disabled", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "ergergergergergerg", ServicePlanId = "57a0746c-87b8-4405-9397-df365a9db793", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "rthrthrthrthrth", ServicePlanId = "113feb6c-3fe4-4440-bddc-54d774bf0318", ProvisioningStatus = "PendingProvisioning", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "fghfhfghfghfgh", ServicePlanId = "363430d1-e3f7-43bc-b07b-767b6bb95e4b", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                    },
                    FruitColors = new Dictionary<string, Color>
                    {
                        { "Banana", Color.Yellow },
                        { "Orange", Color.Orange },
                        { "Apple", Color.Red },
                        { "Lemon", Color.Yellow },
                    },
                },
                new UserLicense{
                    ObjectId = "v4j5cvGGr0GRqy180BHbR3C95mHb--tNguqRKELzlDE",
                    SkuId = "61e6bd70-fbdb-4deb-82ea-912842f39431",
                    SkuPartNumber = "fghfgfgh",
                    ServicePlans = new ServicePlan[]{
                        new ServicePlan{ ServicePlanName = "ergergergerg", ServicePlanId = "4ade5aa6-5959-4d2c-bf0a-f4c9e2cc00f2", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                    },
                    FruitColors = new Dictionary<string, Color>
                    {
                        { "Banana", Color.Yellow },
                        { "Orange", Color.Orange },
                        { "Apple", Color.Red },
                        { "Lemon", Color.Yellow },
                    },
                },
                new UserLicense{
                    ObjectId = "v4j5cvGGr0GRqy180BHbR1BacTSSfW9Cmen4FeCuHeU",
                    SkuId = "34715a50-7d92-426f-99e9-f815e0ae1de5",
                    SkuPartNumber = "rthrthrthrth",
                    ServicePlans = new ServicePlan[]{
                        new ServicePlan{ ServicePlanName = "tyjtyjtyjtyj", ServicePlanId = "fe47a034-ab6d-4cb4-bdb4-9551354b177e", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                    },
                    FruitColors = new Dictionary<string, Color>
                    {
                        { "Banana", Color.Yellow },
                        { "Orange", Color.Orange },
                        { "Apple", Color.Red },
                        { "Lemon", Color.Yellow },
                    },
                },
                new UserLicense{ ObjectId = "v4j5cvGGr0GRqy180BHbR4-OoSYUTfhGg1rtO6QkqWE",
                    SkuId = "26a18e8f-4d14-46f8-835a-ed3ba424a961",
                    SkuPartNumber = "tyjtyjtyjtyj",
                    ServicePlans = new ServicePlan[]{
                        new ServicePlan{ ServicePlanName = "tyjtyjtyjtyjtyuk", ServicePlanId = "113feb6c-3fe4-4440-bddc-54d774bf0318", ProvisioningStatus = "PendingProvisioning", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "yrukyukryukryukryuk", ServicePlanId = "018fb91e-cee3-418c-9063-d7562978bdaf", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                    },
                    FruitColors = new Dictionary<string, Color>
                    {
                        { "Banana", Color.Yellow },
                        { "Orange", Color.Orange },
                        { "Apple", Color.Red },
                        { "Lemon", Color.Yellow },
                    },
                },
                new UserLicense{
                    ObjectId = "v4j5cvGGr0GRqy180BHbR6fhLEGZpLNBjrazjyu8XD8",
                    SkuId = "412ce1a7-a499-41b3-8eb6-b38f2bbc5c3f",
                    SkuPartNumber = "ryukyruk",
                    ServicePlans = new ServicePlan[]{
                        new ServicePlan{ ServicePlanName = "fhjkruykyrukyruk", ServicePlanId = "113feb6c-3fe4-4440-bddc-54d774bf0318", ProvisioningStatus = "PendingProvisioning", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "ryukryukryuk", ServicePlanId = "ca4be917-fbce-4b52-839e-6647467a1668", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                    },
                    FruitColors = new Dictionary<string, Color>
                    {
                        { "Banana", Color.Yellow },
                        { "Orange", Color.Orange },
                        { "Apple", Color.Red },
                        { "Lemon", Color.Yellow },
                    },
                },
                new UserLicense{
                    ObjectId = "v4j5cvGGr0GRqy180BHbRy2tCBUCWOZEv-hvtl3mPSg",
                    SkuId = "1508ad2d-5802-44e6-bfe8-6fb65de63d28",
                    SkuPartNumber = "yukryukryukyrukryuk",
                    ServicePlans = new ServicePlan[]{
                        new ServicePlan{ ServicePlanName = "yurkryukryukryukryuk", ServicePlanId = "113feb6c-3fe4-4440-bddc-54d774bf0318", ProvisioningStatus = "PendingProvisioning", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "ryukryukryukryuk", ServicePlanId = "874d6da5-2a67-45c1-8635-96e8b3e300ea", ProvisioningStatus = "PendingInput", AppliesTo = "Company"  },
                    },
                    FruitColors = new Dictionary<string, Color>
                    {
                        { "Banana", Color.Yellow },
                        { "Orange", Color.Orange },
                        { "Apple", Color.Red },
                        { "Lemon", Color.Yellow },
                    },
                },
                new UserLicense{
                    ObjectId = "v4j5cvGGr0GRqy180BHbR0qii0ipOXNEjuUZKR5xsAI",
                    SkuId = "488ba24a-39a9-4473-8ee5-19291e71b002",
                    SkuPartNumber = "ryukryukryukyruk", ServicePlans = new ServicePlan[]{
                        new ServicePlan{ ServicePlanName = "yukyukryukryuk", ServicePlanId = "113feb6c-3fe4-4440-bddc-54d774bf0318", ProvisioningStatus = "PendingProvisioning", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "ryukyukryukryukryuk", ServicePlanId = "871d91ec-ec1a-452b-a83f-bd76c7d770ef", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "hrththetyjetyj", ServicePlanId = "e7c91390-7625-45be-94e0-e16907e03118", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                    },
                    FruitColors = new Dictionary<string, Color>
                    {
                        { "Banana", Color.Yellow },
                        { "Orange", Color.Orange },
                        { "Apple", Color.Red },
                        { "Lemon", Color.Yellow },
                    },
                },
                new UserLicense{
                    ObjectId = "v4j5cvGGr0GRqy180BHbR66jsdw_s4dEhGqmQCYvrfQ",
                    SkuId = "dcb1a3ae-b33f-4487-846a-a640262fadf4",
                    SkuPartNumber = "tyjetyjetyj", ServicePlans = new ServicePlan[]{
                        new ServicePlan{ ServicePlanName = "etyjetyjetyjetyj", ServicePlanId = "113feb6c-3fe4-4440-bddc-54d774bf0318", ProvisioningStatus = "PendingProvisioning", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "ghdjtjetyjtyj", ServicePlanId = "d20bfa21-e9ae-43fc-93c2-20783f0840c3", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "teyjteyjetyjetyjtyj", ServicePlanId = "17ab22cd-a0b3-4536-910a-cb6eb12696c0", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "etyjetyjetyjteyj", ServicePlanId = "d5368ca3-357e-4acb-9c21-8495fb025d1f", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "teyjetyjteyjetyjetjy", ServicePlanId = "50e68c76-46c6-4674-81f9-75456511b170", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                    },
                    FruitColors = new Dictionary<string, Color>
                    {
                        { "Banana", Color.Yellow },
                        { "Orange", Color.Orange },
                        { "Apple", Color.Red },
                        { "Lemon", Color.Yellow },
                    },
                },
                new UserLicense{
                    ObjectId = "v4j5cvGGr0GRqy180BHbR08SXrDMx6BFpqqM94yUaWg",
                    SkuId = "b05e124f-c7cc-45a0-a6aa-8cf78c946968",
                    SkuPartNumber = "tyejetyjetyjetyj", ServicePlans = new ServicePlan[]{
                        new ServicePlan{ ServicePlanName = "teyjteyjteyj", ServicePlanId = "113feb6c-3fe4-4440-bddc-54d774bf0318", ProvisioningStatus = "PendingProvisioning", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "etyjetyj", ServicePlanId = "14ab5db5-e6c4-4b20-b4bc-13e36fd2227f", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "tyjetyjetyjetyjetyj", ServicePlanId = "2e2ddb96-6af9-4b1d-a3f0-d6ecfd22edb2", ProvisioningStatus = "PendingInput", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "etyjteyjetyjety", ServicePlanId = "5689bec4-755d-4753-8b61-40975025187c", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "tuilutilutiltuil", ServicePlanId = "6c57d4b6-3b23-47a5-9bc9-69f17b4947b3", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "tuiltuituiltuil", ServicePlanId = "bea4c11e-220a-4e6d-8eb8-8ea15d019f90", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "yejytjetyjteyty", ServicePlanId = "c1ec4a95-1f05-45b3-a911-aa3fa01094f5", ProvisioningStatus = "PendingInput", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "tyjetyketuykketyj", ServicePlanId = "eec0eb4f-6444-4f95-aba0-50c24d67f998", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "etyj56jtyjetyj", ServicePlanId = "8a256a2b-b617-496d-b51b-e76466e88db0", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "tyjkytukyjhmteyj", ServicePlanId = "41781fb2-bc02-4b7c-bd55-b576c07bb09d", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                    },
                    FruitColors = new Dictionary<string, Color>
                    {
                        { "Banana", Color.Yellow },
                        { "Orange", Color.Orange },
                        { "Apple", Color.Red },
                        { "Lemon", Color.Yellow },
                    },
                },
                new UserLicense{
                    ObjectId = "v4j5cvGGr0GRqy180BHbR8VvEuqeoeJCpzHanUN7_88",
                    SkuId = "ea126fc5-a19e-42e2-a731-da9d437bffcf",
                    SkuPartNumber = "tyjtryjtyj", ServicePlans = new ServicePlan[]{
                        new ServicePlan{ ServicePlanName = "tyjtyjtyj", ServicePlanId = "97f29a83-1a20-44ff-bf48-5e4ad11f3e51", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "tyjtyjtyj", ServicePlanId = "1412cdc1-d593-4ad1-9050-40c30ad0b023", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "tyjtryjtyj", ServicePlanId = "113feb6c-3fe4-4440-bddc-54d774bf0318", ProvisioningStatus = "PendingProvisioning", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "tyjtyjtryj", ServicePlanId = "0b03f40b-c404-40c3-8651-2aceb74365fa", ProvisioningStatus = "Disabled", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "tyrjtryjrytuk", ServicePlanId = "b650d915-9886-424b-a08d-633cede56f57", ProvisioningStatus = "Disabled", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "gjf,fhj,hfj,fhj,,fjh,", ServicePlanId = "03acaee3-9492-4f40-aed4-bcb6b32981b6", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "ryukyrukyruk", ServicePlanId = "e95bec33-7c88-4a70-8e19-b10bd9d0c014", ProvisioningStatus = "Disabled", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "yrukyrukyuk", ServicePlanId = "5dbe027f-2339-4123-9542-606e4d348a72", ProvisioningStatus = "Disabled", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "yrukryukryuk", ServicePlanId = "fe71d6c3-a2ea-4499-9778-da042bf08063", ProvisioningStatus = "Disabled", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "yrukryukyruk", ServicePlanId = "fafd7243-e5c1-4a3a-9e40-495efcb1d3c3", ProvisioningStatus = "Disabled", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "ryukyrukryukuo;l", ServicePlanId = "d56f3deb-50d8-465a-bedb-f079817ccac1", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                    },
                    FruitColors = new Dictionary<string, Color>
                    {
                        { "Banana", Color.Yellow },
                        { "Orange", Color.Orange },
                        { "Apple", Color.Red },
                        { "Lemon", Color.Yellow },
                    },
                },
                new UserLicense{
                    ObjectId = "v4j5cvGGr0GRqy180BHbR8x8brXH1R9CojtcGL2618A",
                    SkuId = "b56e7ccc-d5c7-421f-a23b-5c18bdbad7c0",
                    SkuPartNumber = "ryukryukryukyukryuk", ServicePlans = new ServicePlan[]{
                        new ServicePlan{ ServicePlanName = "ryukyrukryukryukryuk", ServicePlanId = "113feb6c-3fe4-4440-bddc-54d774bf0318", ProvisioningStatus = "PendingProvisioning", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "yrukryukryukryukryuk", ServicePlanId = "2d925ad8-2479-4bd8-bb76-5b80f1d48935", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "ryukryukryukryukryuk", ServicePlanId = "048a552e-c849-4027-b54c-4c7ead26150a", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "yrukryuryukryukryukryukryuk", ServicePlanId = "300b8114-8555-4313-b861-0c115d820f50", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                    },
                    FruitColors = new Dictionary<string, Color>
                    {
                        { "Banana", Color.Yellow },
                        { "Orange", Color.Orange },
                        { "Apple", Color.Red },
                        { "Lemon", Color.Yellow },
                    },
                },
                new UserLicense{
                    ObjectId = "v4j5cvGGr0GRqy180BHbR5puJTq2FZJAsNyCmT9N68Y",
                    SkuId = "3a256e9a-15b6-4092-b0dc-82993f4debc6",
                    SkuPartNumber = "yrukryukgfgjmmtyutyukryuk", ServicePlans = new ServicePlan[]{
                        new ServicePlan{ ServicePlanName = "uykryukryukryukr", ServicePlanId = "113feb6c-3fe4-4440-bddc-54d774bf0318", ProvisioningStatus = "PendingProvisioning", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "ryukryukyuyjmuiyiukdtyj", ServicePlanId = "2d925ad8-2479-4bd8-bb76-5b80f1d48935", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "yrukyrukyruyrukryukyurk", ServicePlanId = "7e6d7d78-73de-46ba-83b1-6d25117334ba", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "yrukyruryukryukryukyruu", ServicePlanId = "874fc546-6efe-4d22-90b8-5c4e7aa59f4b", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "yukryukryukryukryuk", ServicePlanId = "300b8114-8555-4313-b861-0c115d820f50", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "yjtyjtyjtyjtyjyukuiluiktyj", ServicePlanId = "f815ac79-c5dd-4bcc-9b78-d97f7b817d0d", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "tytyjejetyjteyjteyjtyj", ServicePlanId = "5ed38b64-c3b7-4d9f-b1cd-0de18c9c4331", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                    },
                    FruitColors = new Dictionary<string, Color>
                    {
                        { "Banana", Color.Yellow },
                        { "Orange", Color.Orange },
                        { "Apple", Color.Red },
                        { "Lemon", Color.Yellow },
                    },
                },
                new UserLicense{
                    ObjectId = "v4j5cvGGr0GRqy180BHbRygWSmqam01CvtVBGPDt4_0",
                    SkuId = "6a4a1628-9b9a-424d-bed5-4118f0ede3fd",
                    SkuPartNumber = "ghjkghjkghjk", ServicePlans = new ServicePlan[]{
                        new ServicePlan{ ServicePlanName = "jhkryukyutktyj", ServicePlanId = "113feb6c-3fe4-4440-bddc-54d774bf0318", ProvisioningStatus = "PendingProvisioning", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "tyjetyjetyjtyjtyetjetyj", ServicePlanId = "3f2afeed-6fb5-4bf9-998f-f2912133aead", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                    },
                    FruitColors = new Dictionary<string, Color>
                    {
                        { "Banana", Color.Yellow },
                        { "Orange", Color.Orange },
                        { "Apple", Color.Red },
                        { "Lemon", Color.Yellow },
                    },
                },
                new UserLicense{
                    ObjectId = "v4j5cvGGr0GRqy180BHbR0mPksW6EvdIraMNdDo2AdU",
                    SkuId = "c5928f49-12ba-48f7-ada3-0d743a3601d5",
                    SkuPartNumber = "tyjtyjtyj",
                    ServicePlans = new ServicePlan[]{
                        new ServicePlan{ ServicePlanName = "hjkghjkghjk", ServicePlanId = "da792a53-cbc0-4184-a10d-e544dd34b3c1", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "ghjkghjkghk", ServicePlanId = "2bdbaf8f-738f-4ac7-9234-3c3ee2ce7d0f", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "ghjkghjkghj", ServicePlanId = "113feb6c-3fe4-4440-bddc-54d774bf0318", ProvisioningStatus = "PendingProvisioning", AppliesTo = "Company"  },
                        new ServicePlan{ ServicePlanName = "ghjkghjkghjkghjghj", ServicePlanId = "663a804f-1c30-4ff0-9915-9db84f0d1cea", ProvisioningStatus = "Success", AppliesTo = "Company"  },
                    },
                    FruitColors = new Dictionary<string, Color>
                    {
                        { "Banana", Color.Yellow },
                        { "Orange", Color.Orange },
                        { "Apple", Color.Red },
                        { "Lemon", Color.Yellow },
                    },
                },
            },
        };
    }
}