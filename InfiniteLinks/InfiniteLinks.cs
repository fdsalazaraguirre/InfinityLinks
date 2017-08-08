using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace InfiniteLinks
{
    [TestClass]
    public class UnitTestInfiniteLink
    {
        private WebRequest wrGETURL;
        private string sUrl;
        private ArrayList SecretMessages = new ArrayList();
        private ArrayList AllLinks = new ArrayList();
        /*
        [TestMethod]
        public void GetLink()
        {
            Console.WriteLine("probando");
            try
            {
                var Html = ReadHtml("qds.html");
                SecretMessages.Add(GetSecretMessage(Html));
                ArrayList links123;
                links123 = RecorrerLinks(GetNextLink(Html));
                do
                {
                    if (links123 != null)
                    {
                        links123 = RecorrerLinks(GetNextLink(Html));
                    }
                } while (links123 != null);
                foreach (var secretmessage in SecretMessages)
                {
                    Console.WriteLine(secretmessage);
                }
                Assert.IsNull(links123);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Assert.Fail();
            }
        }*/
        [TestMethod]
        public void ExecMethod() {
            string[] Students = {"30070ce4-7cec-4be6-9e43-410c122856be", "2e800000-0000-4555-a001-000000338119", "cacc33e3-f803-4645-9d37-6340bf7e6849", "deac64b7-fa17-4987-a38a-0653e7d61247", "c44636cb-96d3-4f26-8680-3b896c93d188", "83433a1c-9283-4516-8e98-eef3f90f7f46", "f8ed93d0-80ce-4742-aecb-79a72fe978ab", "b66e2085-0aa9-4397-8d8d-4cd41d696bc1", "2ca31c56-252d-4233-8d5c-788d6010ad06", "39b8526c-906d-452f-a13c-0a0f29e81bc7", "10fd860a-215d-4bb9-89bf-02ec28f439c6", "85fa8f77-4275-4a93-89fb-ae150f298c9b", "1e1474eb-3f66-47fe-81b5-575d599070a6", "2e800000-0000-4555-a001-000000290514", "fb2f161e-4e87-45a6-94ce-5ac5afd3da2c", "4a4fd6d2-3e00-48dd-8096-a84ec30a5329", "5fac17c1-bb0f-46b4-b68c-dc85502d2ce1", "77a3ee41-8c17-4e83-b399-6a1f0ab8642b", "92b4d268-d4e9-42dd-bae7-968bb2268656", "aa8564a3-1f5d-4812-b849-0b0cc77af803", "9bc931bb-2d24-4026-b5da-72a7e5d89563", "2e800000-0000-4555-a001-000000351104", "a34aa2b4-e00e-42d1-ac12-bffbad7b9372", "6083a034-c831-436f-9980-e7ea41613705", "4b65d8b5-8551-4c0c-b99a-719fb2fb7e21", "a3a395c1-0e8f-447c-b051-70b2e5dbd2ee", "4da0c705-52a9-4f08-b8bd-8169dec89840", "c67fc23b-6628-4801-9624-80ff685fbd3c", "4b43fc72-6e13-43b6-a96b-b644b419cf27", "91b87388-271b-4d18-a9c7-3436a1fcf742", "68cbe8fe-a95e-4b41-8beb-1639cc52629d", "31a1cda7-6af2-47f1-9818-32874e747f3f", "13b35263-2eb7-492e-b0c0-addabe398565", "83d61741-ed86-476c-a430-37ecdc0193b3", "e5c9fcd8-05c5-4adb-8442-ae5e5cfa80ab", "3a4902ce-9265-44f0-9266-e0d0feb3e332", "49ab95a3-9141-4777-836c-1021b2c085e7", "1a3eed8a-16e9-481a-9c2e-e152ee690c54", "ef7317e6-96e3-4bec-b296-1fd5965be2c5", "2e800000-0000-4555-a001-000000286420", "3ac9ff66-8310-4599-82d4-daeb97ee7bc5", "2e800000-0000-4555-a001-000000340421", "b4a8d9d9-e02c-434a-afc4-33f0dea86155", "2e800000-0000-4555-a001-000000275779", "c142cc39-dbcc-45db-9507-f7072f452a69", "7e86d023-6ad1-43ed-a6b5-f7eeea073bb7", "34bd19cd-e62a-4a5d-a031-7c3ccaf1f83c", "15345c4e-8a9d-4b14-942e-94f095cdbf5d", "2e800000-0000-4555-a001-000000333835", "a6d607f2-2b9f-4cdb-9641-883884dfd429", "cc2152b3-8d05-489d-8be5-a98167460190", "0b87ca8c-0841-406a-ba9a-986ff918c53e", "2eadce96-9132-4138-9cf7-026b465b506d", "f232e431-d19b-4d88-992a-be5590f8d18d", "a8e8d9a9-de9f-4443-a296-8445e413244e", "f6b94587-775d-4c36-9728-dabd4559022f", "2e800000-0000-4555-a001-000000318804", "6b0fa64c-3275-49aa-9a73-354831c4ac10", "ef0baf41-3d9f-44a3-b8de-d4d639df513a", "84701d3a-48b2-43c4-8407-e035113f1e0b", "8498b763-cc65-4f78-8bb1-d1ecd31b0a2d", "97e8660e-ad4f-47ca-8835-c05905dd7b8e", "1b9d8e35-5654-47ee-bfc4-81fbb2334263", "7944ab1d-d1b7-440f-956f-c8200b8a6cce", "3a389db7-4a1a-4a59-9114-7df79e5fae16", "2e800000-0000-4555-a001-000000350345", "4506d78e-b70c-4670-a30c-505361b356ce", "2e800000-0000-4555-a001-000000320126", "2e800000-0000-4555-a001-000000278041", "bbaed8eb-8614-4309-89b9-78a4726157b8", "ab2554a0-272c-4327-a3d1-65319f6442ea", "934f4444-1400-4bd5-8a2f-50089423a3b6", "6dd0553d-a31c-46f1-b429-408f2449456e", "66d7e486-7502-416a-bc64-7e3c32460093", "4069aa85-e237-4f45-814d-66830aa38a16", "05c8cc66-baf2-4af9-9341-5fa153a98790", "360f9c74-33f2-41fa-9b65-28e0bb620e9b", "7bcc2574-39fe-4e51-90ac-6116d02d8fe5", "8d5e1f75-9ec0-483b-b3fd-3e0fbc351c13", "2e800000-0000-4555-a001-000000238008", "79d821ee-0119-4d01-86f7-0657d06afd2e", "921ee8db-9ec1-43b6-af3f-28816da3d1fd", "b1ff28a1-346d-4ad3-a834-979c1552e163", "2e800000-0000-4555-a001-000000142846", "42a21e11-5354-49a0-9e08-c90d6b1adf01", "faa87d53-bf30-4e81-a25d-cfe97efdd5a5", "65ce9755-685d-4f04-b3c2-cc5a8ff77a7a", "5825e3a1-2220-455a-888e-2968f59606ad", "018d8fd1-0c2d-4a95-a14c-8c148aec14aa", "2e800000-0000-4555-a001-000000293472", "40827854-4a52-4de3-855a-247ca8c1dfab", "d88cbdd5-d43f-4c44-91d4-45ea67ecc749", "33225b86-94bd-41f0-951f-be3122e21f88", "b454394d-3c14-4c5a-b70c-1d6734911c03", "be3f3117-5632-454d-bdc7-e58d9dafada7", "a85834a2-3848-4674-b8e3-d6c4eca322a2", "29f692dc-c036-4fdc-bb48-a53a60faf283", "eb250281-7a27-4dcf-b136-62a1053d551e", "7d1de214-b0ba-418d-b9f1-4cdba67c07cc", "b22c9908-a7cb-482c-bfcb-7662ffde6d80", "2e800000-0000-4555-a001-000000210124", "c70d4712-789f-460c-a02d-1f1ef7ad445f", "2e800000-0000-4555-a001-000000346818", "a1e44cf1-a239-4be6-9b95-e92707ba5a5c", "3901edd2-df05-415d-9a8b-1be45556ea02", "2e800000-0000-4555-a001-000000173860", "ffb976ae-a789-4017-a43c-93e0fe5fa4ff", "6eb90b61-a4e4-4528-b5b1-78636f8432b6", "e48eeae2-23c2-4caf-8a9d-e4a66727776a", "5991e4a4-0d6a-417b-b96c-fd5f84aa5be2", "2e800000-0000-4555-a001-000000314986", "2e800000-0000-4555-a001-000000284163", "b0c701e4-0197-44b4-891c-5f91af6ee3b9", "1a861ddf-02c7-4066-b8d0-322284b55ee1", "e0e58631-cb20-458d-898e-c7f7c969449f", "bca70b01-d85c-4bd6-b74d-5ab707fcbdc7", "5222370b-6571-4c1a-854f-eb54f27bb2bb", "2e800000-0000-4555-a001-000000273036", "71831799-3773-46eb-ad4f-b95804bd6fea", "89a747f3-19df-44f4-9621-1486cbfe3fbd", "0b527913-02be-4da1-b917-1e109b1741a3", "2e800000-0000-4555-a001-000000331337", "54e7aded-e1a4-4180-a918-250839de2810", "94fa8f15-a630-450d-b5a5-2effa816da64", "5edeca7d-fdf9-4e63-b01f-97cf3d7ad4fb", "2dd9c79b-6ac7-40a8-a29e-40cb257384f1", "9ce8a37c-e928-4a2a-a768-b7df47a6c946", "80c857ac-b69e-445f-9922-1969b238047a", "de2a7ece-8434-4f93-8869-49b306cb66e4", "f7ba6aab-6e54-474c-879f-ac1e1e6545e8", "decc9003-b244-4137-8f64-6de4615e9e30", "f455dafe-39b0-4f61-ab2a-4b20a838f687", "bea8ce04-ddd5-463a-8798-cd3ef4f33bfc", "6167a1a9-69ae-449c-9e54-9599df927c45", "2e800000-0000-4555-a001-000000333320", "05fc17f2-b976-4251-b514-f367a3f2fddf", "e5bc6d33-18d1-4e34-a000-8ff3c6ffb366", "f4b2ce5c-3787-4110-9dc9-23287d0676a9", "881b176a-672b-4a94-9017-aeb2f89a6fc1", "dbe6a174-204d-4a41-9267-e0b8ef9893d1", "47f2d178-e3d1-4d7c-8751-a0215969f892", "278b1034-7910-4b5a-bc2f-6f967e17b956", "50f4a0c8-1af2-4c2f-a253-04feeebc77c7", "80a18b56-96ed-4a1f-bd17-dfc1943babf6", "2e800000-0000-4555-a001-000000350890", "19a773e8-a516-479e-b320-34573fa97c38", "0dfc21ae-18dc-49e8-8396-7d9648e06165", "be378d5d-c4bc-444f-8223-6d78ea8ed3f6", "969bb335-fead-40e7-a8e8-0c17afca8dc4", "3574b025-3c4f-4d23-89d5-f8626f3ab6d9", "327dba0d-f207-4b4d-8e9a-d0c6f97acdf9", "2e800000-0000-4555-a001-000000314438", "f7dcab64-2f22-4462-aea2-7ba4e8a43dfe", "89e4f94c-ddb8-41f0-87b9-cca97d0185b1", "30f114b0-1538-4357-9170-26212b509028", "2e800000-0000-4555-a001-000000320929", "6d228f15-8d48-464e-86a8-26088b533470", "1f6e3159-8dbe-475f-91c8-e9d7f8b29acb", "f641aa23-b516-4d6c-8197-acd719dc25f2", "2e800000-0000-4555-a001-000000309042", "94e9e6dc-29e9-4364-9e87-8af0b6ef7f47", "2460bb36-f101-4bd7-8382-a98bc5ab9545", "e9309bbe-dc4f-44c2-b447-9578733ebe7b", "45fef557-0774-4f16-86e8-cab870e6870a", "69ceeb85-46ef-411f-9dec-759272812b95", "38394a8a-1a56-4f30-af84-f528d51a59af", "1e193e7e-d51d-4526-a0d5-9ac2e6550a73", "8132d4d7-de2c-458d-b113-6ad8826b66e9", "05466688-49c8-46d9-be26-5fbdba72a74d", "6047274b-9828-47ea-a934-ba8b2d7014cf", "58147b80-fe21-42f2-82a2-a0fafee8636b", "58ccd784-f3c2-42e0-8d75-5a3fb1c23dd6", "d62b261e-feea-4023-a4dc-2756c0447fc4", "1b70e71d-c3e1-4e36-9147-38adf6271733", "89079399-c224-4cf8-bb22-f3ba03802544", "891e23e1-0ce7-4e55-b774-bac235e6955d", "2e800000-0000-4555-a001-000000307168", "c09eb474-e47a-496a-9579-ba4c1e7404a2", "0123bacd-3fb9-4c4e-b199-f75ec1e36cf0", "1cfc39e6-fe64-42af-93f1-249473927f96", "2e800000-0000-4555-a001-000000192762", "2e800000-0000-4555-a001-000000346020", "41d7d631-e8b3-4528-ac46-b47a6d16b5c2", "06a128e2-6690-4d26-9a0d-0f9a3731b4af", "2e800000-0000-4555-a001-000000321901", "e51d55b0-f50e-425d-95c3-c7ec52e6593e", "9cfbe939-27aa-4729-a11f-6600df8d9aea", "5d1c437b-77e7-412e-bd6c-bbfea4101e20", "3cff88b9-9a92-4b46-9b04-fdd373616178", "00aa0303-f7bf-4b98-8e92-5bbbc7438bae", "8411285f-8ee6-45a7-a66b-1b98f52e0cdc", "2e800000-0000-4555-a001-000000350254", "af85545e-97c5-4ca0-b3ff-3edbc53a674a", "a47689ed-fe99-42ea-88ff-dfa3d082548f", "56591350-35f1-4406-80e7-61a8c7d54bca", "2e800000-0000-4555-a001-000000305338", "fa26bcad-7b28-4626-ae73-a5625db61339", "0f6708c0-a190-4b6c-9fb9-594aacadd87e", "3c2f1889-1dbc-48d4-bb28-5a24692fd8c5", "2e800000-0000-4555-a001-000000281320", "59e1d0f0-a22a-4a83-bcd5-549cb0155c3d", "e8bcda31-9dec-428c-a53d-e876de3569cc", "b92ce54e-0f91-4220-a56e-f93d7ab3eb2d", "2e800000-0000-4555-a001-000000337005", "a333416e-ec2e-4d32-a10b-5cfeca7fe9cb", "1a664156-5187-4ab0-9aa6-8455d4c926d8", "2e800000-0000-4555-a001-000000285820", "691de951-d996-46d6-be23-918450923994", "863cfa39-5436-48dd-a106-ecc9315a962c", "3d19849d-86f1-4189-b101-5d1beb00e5c6", "101e900a-3822-43f5-a5ab-d6af51f5ceeb", "f8877b51-4c65-4887-bc17-00641b2f018d", "58b2d3da-ed7c-44ac-83f6-18894860e287", "8030065f-27c2-432d-8f49-b2f01e059267", "2e800000-0000-4555-a001-000000307709", "38df97e6-8a2c-4e3c-abe6-d797ebb395f1", "ccb656b8-6e64-4662-875d-c59240ee5882", "91f7b4b5-3da5-412a-9235-d8be91d97bd9", "5169e7ad-5074-4c26-b41b-f7f3e920bb8f", "b8a0f289-ee9b-4a1a-8f7e-fbcb94584a73", "d8dd502d-a87b-489f-984c-36b4d10b60f1", "a0de9a50-b044-4e71-9980-b0bc7266837d", "1f00cb60-e7c1-42a8-bf37-722c3d6a86b5", "80afc96d-98ca-4a5a-b578-dc255616992a", "c2505b9c-ae1c-4890-8b74-ad148aa8a755", "18e474ea-56a7-4771-b0de-eed7e3014884", "0af8cc84-7e6b-47ea-a6a2-e0597b11502b", "63e085db-efda-4035-9a79-5d5ec56d7433", "2e800000-0000-4555-a001-000000313688", "95bad5ae-dd6c-4421-a57f-777ccf665fdc", "33d69801-8cdf-430c-9b64-58095844946b", "fc80c4a3-5dcf-465d-96c8-28b179dc6df4", "f217432a-8d6b-4770-a28c-d3e7c81888d5", "e4f7964d-d2e8-4e0d-9e4c-04df0c368488", "45b1e684-f606-4b04-ac14-6997a8553e58", "a7a370a8-0e6b-4aa5-b40d-d33425c58b00", "d28a6ac5-612e-4a57-801e-9d87d0f37b2f", "f689dab9-f71d-4729-b133-b363d29a1614", "2b96e40c-3356-4f9c-9f57-01470dd6e3a5", "050448b9-a511-4696-8477-4034a705a247", "065f3f87-fd6b-4852-a610-ea096bfd1d83", "ddd2fe00-89e5-4468-8ab9-27efa014db77", "2e800000-0000-4555-a001-000000346331", "63ffd817-3d85-45f2-b45e-c27cee5f5e2f", "2e800000-0000-4555-a001-000000293275", "15c3aa7c-b71e-4f6b-9c91-49adf671e787", "535b88d7-8da4-46f6-abff-bc9253811ab0", "2e800000-0000-4555-a001-000000335305", "681604b6-0b92-4e2f-a96c-a9fbcf3dd925", "2e800000-0000-4555-a001-000000164950", "3caa625b-6c3d-4d90-8f02-3f1193aff526", "01c4f224-1859-4435-afaa-5ec8d92c8260", "5e0447b9-c89a-4410-8b6c-d2c54b7695d2", "94068628-d6ef-4e69-a089-76769b620199", "ef13a399-0223-4d14-8c3e-8e768a506f74", "e76cb265-1aad-4710-9193-ff8cf4f8b4e8", "2d218ba1-598a-42c4-9446-61dd33b3201e", "d1843668-756f-49e1-9003-e60d9755f6d5", "fdc14d30-3a61-4794-a9e7-ad14ee47e09f", "3df34504-1182-4f11-a896-da48225e3ef0", "f40d9388-1c68-4e2f-b086-b27ab0ca69e5", "7f3146c6-7bdc-4e87-b8a5-f246e5a05ab7", "0dee12f2-7a4e-4dc9-9bd4-15cb2537eaaf", "bd6e5602-0cc0-4284-9135-a354803c021e", "329fbeba-23b3-4918-ae74-b2907501fc48", "2e800000-0000-4555-a001-000000213067", "580ed964-da0a-4a00-9443-fa9f636a9a22", "7a19f52e-9fbf-4477-9444-b4341f142020", "78364001-9388-47f4-96a3-96a078ece806", "01862825-ad7c-4e58-9cb5-2717507564da", "f26e183a-4d64-4d93-a9f8-a31996e6b17e", "2e800000-0000-4555-a001-000000342170", "08f34174-af6f-4c55-a813-6bf1bd19da48", "0025147b-bcc8-409a-b40c-043206dc21e4", "97491d72-4a53-4926-a882-e3d8c14c7f70", "6ea3b8fd-f99a-43f3-98aa-790fc6636e47", "00994833-8509-4b56-9cd9-ffb7133ad722", "527bcc3c-6bf1-4e7f-ba01-5b25d6268fdf", "45a78367-6f80-4bd8-afb4-434007e07deb", "762499c7-af4f-416e-a950-928feba63e29", "91edacfc-ff76-4957-9838-1cf16051e3a6", "b7ecb4a1-74a5-454c-876e-8812d436e346", "53f869d1-1f37-45f5-b1c1-6e8cce972178", "04318505-5644-4bd8-9a55-87332f269ed2", "bfd550bd-26b7-4775-9145-03a5b2b51731", "475a3c11-3dd0-4617-942c-851e5d5f86ca", "2e800000-0000-4555-a001-000000223666", "15ac8a27-0fc1-4108-81c7-0746f9c246e1", "2e800000-0000-4555-a001-000000292043", "8d16b559-2281-4c09-89c6-bf7e32c14df9", "dc3d8fae-e2af-42af-8e97-295ca4cba439", "d3a6e1eb-75af-4289-b56e-49c6cbf67ea8", "c5bed90a-42fb-44d2-b6ef-648af31a2e1c", "bfb99482-d4b3-40ad-bc1e-d068c11ee58e", "2e800000-0000-4555-a001-000000195215", "007c56a2-4826-4473-a32c-a1d0c0730727", "d2f77076-51f1-480a-b81d-b3bc497b6786", "eb19bd8a-c87a-4c1e-b3a5-df3f2db142f8", "65f9f8a4-b380-46f8-9460-9ad1f925c4a4", "2e800000-0000-4555-a001-000000094680", "87bec998-f79b-49f1-8bdf-c15c170e2618", "66db0593-087a-434c-a4e7-f1646599ec07", "faf708fe-4b7b-46ed-a8ec-a376a053a454", "0bd1f47c-79e6-49c1-9dca-b5bfe4a0f60e", "56fec524-06ea-4ef0-b37f-a111fcd415f9", "8160e382-a680-4b28-9ba8-080f4bb616e0", "2e800000-0000-4555-a001-000000130826", "068c69bc-14a6-4f0d-8459-c76e4876afe4", "cd5c9d2d-2b69-489a-a9ee-9e5f1a2d72b5", "b57c8f66-5a66-4961-b373-2f7631d86049", "b1fe85fe-b795-4f04-ac58-37003a2b50fa", "9d00f6eb-feb2-4a7f-a8e9-07eccebce484", "21dee3d6-e5a6-4e13-bae5-652fcfc5773a", "160a5087-f5c3-45ff-989d-715c8b69994d", "ef9ebf20-6f53-46d8-902f-cc675d788321", "20e593e9-d318-4b64-8ce5-073598715997", "9973c555-bba8-4589-b199-b943463dab71", "2e800000-0000-4555-a001-000000338175", "2e800000-0000-4555-a001-000000288856", "b4657548-d764-4eaf-9bb6-a0a312da478b", "2fdb36b0-548a-4e16-b896-fc93260099d5", "6b21e386-6780-44b7-8193-4894484f0dd8", "a2fc5865-7a93-4f80-94ff-d8018e9a46ca", "04492ab1-be75-4e6b-9c6c-5001a3f8f3ed", "73e057de-368e-472f-8b5b-baae0b1533a0", "4d37d6f6-aca3-43bc-8d12-8346ba031e06", "78dc490b-d5bb-44d0-b2fe-d99fea56a7ce", "b8b903d2-81c1-449a-ae6f-38815abb40b0", "29372a58-b92f-4a2b-81a6-c953a553a21d", "0a684bb3-9d1a-4929-aedd-074f64e311f8", "3dfc4950-5f3c-4201-9778-202d569d24a9", "b951654e-2c85-468a-b6b6-00410ee402a9", "2e800000-0000-4555-a001-000000268313", "0f139ed4-1279-45a1-b085-ca215d4b39d1", "ec87a069-b3f0-4419-9634-71e0d1d59fdb", "9a86258f-6e55-412f-8996-da17e37a8042", "64b56199-771d-4874-a035-160636b87cbe", "308296ba-35bf-4e1c-8495-8794ad96f3ce", "fb273f48-7761-42d6-8e9c-60635915f143", "958c2d87-9367-46f6-95e0-04a2f46263cf", "fd7b24d3-79db-4ae5-a112-9735f5dd392d", "2e800000-0000-4555-a001-000000277625", "43d5510f-2fa6-4e96-9807-f8a5ce558044", "9a8f73e5-4ace-4728-a598-8b8f92287520", "2e800000-0000-4555-a001-000000342309", "53474c8b-0ff4-4788-9b0c-96ec69b9e84e", "72345885-5503-4535-9205-cc2363514b92", "2e800000-0000-4555-a001-000000332979", "84babe5c-9e21-4453-9c68-b7835ec34a96", "8ff58637-033b-49fd-8205-32fee0bb94b5", "374fff58-c56d-4af3-96be-1b3c7a730d37", "a3473973-826c-4c77-b1ee-6e64badcc457", "2e800000-0000-4555-a001-000000310494", "3fed0389-473c-4103-a53a-dda526061b5f", "4ee6b9f7-e10a-45e0-94cb-d2c6165ddbfc", "7d5c9688-8d3e-45a0-ab24-05ac4e0cbbd8", "cb13b7d7-3b9b-4b8e-a40d-34e3d9302e34", "bda09670-7a09-4949-bc93-d7815254bbf9", "c9b619fc-3362-4532-afef-8cbd38d0a99d", "5736c0e8-40e4-4fa5-9b69-4111372ba7ee", "a5513a54-54b9-46bd-b3c1-73e532dfde54", "32ed02c1-ef3d-472f-9056-5a086c6f7a66", "eb2274af-84f7-4f17-93c6-e22883eb537d", "bc12e79d-2415-4322-9365-b38fdfa78bde", "21c001cb-be0a-4000-9a8b-6e69ab8e9576", "27f2ca76-6159-4f8b-9caa-b21710902f4d", "89c0b2be-8154-4791-8598-63ad8726938a", "f6c63bc5-f5ea-4191-8e0b-f163b610d2f6", "24137fb1-3f4f-4426-a057-ec0153deca7d", "08436b2c-2500-43f3-a1ae-6617f37ca826", "de0958f8-8377-407e-8685-de84919657c4v", "93810425-679c-4a9c-92e0-16f7e6feff90", "bb71403c-8826-48cf-a1df-b329bb4b3df7", "2d52e26f-6331-4ab1-9836-220c1a347495", "16b795c1-bbd7-47e2-ade3-0416df434a7f", "2d714d1d-7d0d-4a91-9ba4-e5a24c3ae573", "1ebd916e-30f3-48f7-9792-1f89deca8131", "7ee48a4c-a00a-4f55-a91a-03103bb998ae", "2e800000-0000-4555-a001-000000335053", "a823e79b-e847-4de1-ad6f-961f04eadb35"};
            foreach(var student in Students)
            {
                Console.WriteLine(GetUrl(student));
            }

        }

        private String ReadHtml(string pagename)
        {
            var request = (HttpWebRequest)WebRequest.Create("https://cdn.hackerrank.com/hackerrank/static/contests/capture-the-flag/infinite/"+pagename);
            request.Method = "GET";
            var response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, System.Text.Encoding.UTF8);
            var html = readStream.ReadToEnd();
            response.Close();
            readStream.Close();
            return html;
        }

        private String GetUrl(string student)
        {
            var request = (HttpWebRequest)WebRequest.Create("https://www.colibrilearning.xyz/api/admin/accounts/"+student+"/statements/sync");
            request.Method = "POST";
            var response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, System.Text.Encoding.UTF8);
            var html = readStream.ReadToEnd();
            response.Close();
            readStream.Close();
            return html;
        }


        private String GetSecretMessage(string html)
        {
            string secretmessage = ""; 
            HtmlDocument doc = new HtmlDocument();
            ArrayList Links = new ArrayList();
            doc.LoadHtml(html);
            if (doc.DocumentNode.SelectNodes("//font[@color='blue']") != null) { 
                foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//font[@color='blue']"))
                {
                    secretmessage = link.InnerText;
                }
                secretmessage = secretmessage.Replace("Secret Phrase: ","");
            }
            return secretmessage;
        }

        private ArrayList GetNextLink(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            ArrayList Links = new ArrayList();
            doc.LoadHtml(html);
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                if(!Links.Contains(att.Value.ToString()))
                {
                    Links.Add(att.Value.ToString());
                }
            }
            return Links;
        }

        private ArrayList RecorrerLinks(ArrayList Links)
        {
            ArrayList list = new ArrayList();
            foreach (var link in Links)
            {
                if (!AllLinks.Contains(link)) { 
                    var Html = ReadHtml(link.ToString());
                    if (!SecretMessages.Contains(GetSecretMessage(Html))) { 
                        SecretMessages.Add(GetSecretMessage(Html));
                    }
                    list.AddRange(GetNextLink(Html));
                    AllLinks.Add(link);
                }
            }
            if (list.Count > 0)
            {
                return RecorrerLinks(list);
            }
            return null;
        }
    }
}
