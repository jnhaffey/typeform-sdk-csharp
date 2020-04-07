using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Bogus;
using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Enums;
using Typeform.Sdk.CSharp.Models.Workspaces;

namespace Typeform.Sdk.CSharp.UnitTests
{
    [ExcludeFromCodeCoverage]
    public static class TestData
    {
        public const string ApiKey = "UNIT_TEST_API_KEY";
        public const string NullValue = null;
        public const string EmptyValue = "";
        public const string WhiteSpaceValue = " ";
        public const string FormTitle = "TEST_FORM";
        public const string InvalidJson = "{{[]}}";
        public static Randomizer BogusRandomizer = new Randomizer(DateTime.UtcNow.Millisecond);
        public static Faker BogusFaker = new Faker();

        public static class Workspace
        {
            private static readonly string FullWorkspaceId = "ABC123";

            private static readonly string FullWorkspaceSelfUrl =
                $"https://api.typeform.com/workspaces/{FullWorkspaceId}";

            private static readonly string FullWorkspaceFormsUrl = $"{FullWorkspaceSelfUrl}/forms";

            public static readonly string DefaultJson = "{\"name\":\"UNIT_TEST_WORKSPACE\"," +
                                                        "\"default\":true," +
                                                        "\"shared\":false," +
                                                        $"\"forms\":{{\"count\":0,\"href\":\"{FullWorkspaceFormsUrl}\"}}," +
                                                        $"\"self\":{{\"href\":\"{FullWorkspaceSelfUrl}\"}}," +
                                                        $"\"members\":[{{\"name\":\"Account Owner\",\"email\":\"owner@example.com\",\"role\":{(int) MemberRoleType.Owner}}}," +
                                                        $"{{\"name\":\"Account Member\",\"email\":\"member@example.com\",\"role\":{(int) MemberRoleType.Member}}}]," +
                                                        $"\"id\":\"{FullWorkspaceId}\"}}";

            public static readonly ViewWorkspace FullViewWorkspace =
                JsonConvert.DeserializeObject<ViewWorkspace>(DefaultJson);

            public static readonly ViewWorkspace Null = null;
        }

        public static class Themes
        {
            public const string Name = "THEME_UNIT_TEST";
            public const string SixCharHexColor = "#000000";
            public const string ThreeCharHexColor = "#000";
        }

        public static class Guards
        {
            public const string ParameterName = "UNIT_TEST_PARAMETER_NAME";
        }

        public static class HiddenProperties
        {
            public const string Property1 = "PROPERTY_1";
            public const string Property2 = "PROPERTY_2";
        }

        public static class Webhook
        {
            public static string JsonResponse1 = File.ReadAllText("WebhookResponse1.json");
            public static string JsonResponse2 = File.ReadAllText("WebhookResponse2.json");

            public static class ResponseRoot
            {
                public const string EventId = "01E58BT3PVFC3D5CN4W8D433ZE";
                public const string EventType = "form_response";

                public static class FormResponse
                {
                    public const string FormId = "gXoeR3";
                    public const string Token = "7l8hjyfrjvt31l0if7l8ub70enlq4vya";
                    public static DateTime LandedAt = DateTime.Parse("2020-04-06T18:23:15Z");
                    public static DateTime SubmittedAt = DateTime.Parse("2020-04-06T18:24:59Z");

                    public static class Calculated
                    {
                        public static int Score = 9;
                    }

                    public static class Hidden
                    {
                        public const string HiddenFieldKey1 = "hiddenfield1";
                        public const string HiddenFieldValue1 = "hidden_value1";
                        public const string HiddenFieldKey2 = "hiddenfield2";
                        public const string HiddenFieldValue2 = "hidden_value2";
                    }

                    public static class Definition
                    {
                        public const string Id = "gXoeR3";
                        public const string Title = "SDK Use";

                        public static class Fields
                        {
                            public static class MultipleChoice_Single_Without_Other
                            {
                                public const string Id = "b6p0eo5faGz7";
                                public const string Title = "MultiChoice (single selection without other option)";
                                public const FieldType Type = FieldType.MultipleChoice;
                                public const string Ref = "sdk_multichoice_single";

                                public static class Properties
                                {
                                }

                                public static class Choices
                                {
                                    public const string Id1 = "LJ0x3iaRMUFi";
                                    public const string Label1 = "Choice1";

                                    public const string Id2 = "IrDCB0aqjmiV";
                                    public const string Label2 = "Choice2";

                                    public const string Id3 = "kfPG92Xg2UKm";
                                    public const string Label3 = "Choice3";
                                }
                            }

                            public static class MultipleChoice_Single_With_Other
                            {
                                public const string Id = "qIxWIZGIJAV4";
                                public const string Title = "MultiChoice (single selection with other option)";
                                public const FieldType Type = FieldType.MultipleChoice;
                                public const bool AllowOtherChoice = true;
                                public const string Ref = "sdk_multichoice_single_other";

                                public static class Properties
                                {
                                }

                                public static class Choices
                                {
                                    public const string Id1 = "Zxsk9Y85dqDH";
                                    public const string Label1 = "Choice1";

                                    public const string Id2 = "eQCGsHyXlTXG";
                                    public const string Label2 = "Choice2";

                                    public const string Id3 = "zKg16wqzWbag";
                                    public const string Label3 = "Choice3";
                                }
                            }

                            public static class MultipleChoice_Multiple_Without_Other
                            {
                                public const string Id = "hnfaIIwfYdsV";
                                public const string Title = "MultiChoice (mulit selection without other option)";
                                public const FieldType Type = FieldType.MultipleChoice;
                                public const bool AllowMultipleSelections = true;
                                public const string Ref = "sdk_multichoice_multi";

                                public static class Properties
                                {
                                }

                                public static class Choices
                                {
                                    public const string Id1 = "q4Mte3CtC4Ac";
                                    public const string Label1 = "Choice1";

                                    public const string Id2 = "VQMdBeDfGtJ6";
                                    public const string Label2 = "Choice2";

                                    public const string Id3 = "OzQ3RZzfl8pt";
                                    public const string Label3 = "Choice3";
                                }
                            }

                            public static class MultipleChoice_Multiple_With_Other
                            {
                                public const string Id = "oy0lMI97wKQG";
                                public const string Title = "MultiChoice (multi selection with other option)";
                                public const FieldType Type = FieldType.MultipleChoice;
                                public const bool AllowMultipleSelections = true;
                                public const bool AllowOtherChoice = true;
                                public const string Ref = "sdk_multichoice_multi_other";

                                public static class Properties
                                {
                                }

                                public static class Choices
                                {
                                    public const string Id1 = "gR4cMzlz8jb8";
                                    public const string Label1 = "Choice1";

                                    public const string Id2 = "OpCM2MMr7RRw";
                                    public const string Label2 = "Choice2";

                                    public const string Id3 = "H7CLIvUxvDmI";
                                    public const string Label3 = "Choice3";
                                }
                            }

                            public static class PhoneNumber
                            {
                                public const string Id = "jRTzbVFtvj5L";
                                public const string Title = "Phone Number";
                                public const FieldType Type = FieldType.PhoneNumber;
                                public const string Ref = "sdk_phonenumber";

                                public static class Properties
                                {
                                }
                            }

                            public static class ShortText
                            {
                                public const string Id = "o6NXRuJwIouc";
                                public const string Title = "Short Text";
                                public const FieldType Type = FieldType.ShortText;
                                public const string Ref = "sdk_shorttext";

                                public static class Properties
                                {
                                }
                            }

                            public static class LongText
                            {
                                public const string Id = "hlTuVzJcMt4v";
                                public const string Title = "Long Text";
                                public const FieldType Type = FieldType.LongText;
                                public const string Ref = "sdk_longtext";

                                public static class Properties
                                {
                                }
                            }

                            public static class PictureChoice_Single_Without_Other
                            {
                                public const string Id = "QbiP5ItH7mAP";
                                public const string Title = "Picture Choice (single selection without other option)";
                                public const FieldType Type = FieldType.PictureChoice;
                                public const string Ref = "sdk_picturechoice_single";

                                public static class Properties
                                {
                                }

                                public static class Choices
                                {
                                    public const string Id1 = "lhP9Q2POJ4at";
                                    public const string Label1 = "Choice1";

                                    public const string Id2 = "YiDfNNxBtrig";
                                    public const string Label2 = "Choice2";

                                    public const string Id3 = "c5zkefIvL3DH";
                                    public const string Label3 = "Choice3";
                                }
                            }

                            public static class PictureChoice_Single_With_Other
                            {
                                public const string Id = "aOCz7ABFtThF";
                                public const string Title = "Picture Choice (single selection with other option)";
                                public const FieldType Type = FieldType.PictureChoice;
                                public const bool AllowOtherChoice = true;
                                public const string Ref = "sdk_picturechoice_single_other";

                                public static class Properties
                                {
                                }

                                public static class Choices
                                {
                                    public const string Id1 = "fIolPJLWdNpZ";
                                    public const string Label1 = "Choice1";

                                    public const string Id2 = "FwcZRdRVj40k";
                                    public const string Label2 = "Choice2";

                                    public const string Id3 = "iABSwSvGfux9";
                                    public const string Label3 = "Choice3";
                                }
                            }

                            public static class PictureChoice_Multiple_Without_Other
                            {
                                public const string Id = "fThk3NrYI3DJ";
                                public const string Title = "PictureChoice (mulit selection without other option)";
                                public const FieldType Type = FieldType.PictureChoice;
                                public const bool AllowMultipleSelections = true;
                                public const string Ref = "sdk_picturechoice_multi";

                                public static class Properties
                                {
                                }

                                public static class Choices
                                {
                                    public const string Id1 = "ZDExcxH9RdVw";
                                    public const string Label1 = "Choice1";

                                    public const string Id2 = "vO3xkbbFvp0l";
                                    public const string Label2 = "Choice2";

                                    public const string Id3 = "t30L9bxl4sVn";
                                    public const string Label3 = "Choice3";
                                }
                            }

                            public static class PictureChoice_Multiple_With_Other
                            {
                                public const string Id = "IAFWMalgu2Rz";
                                public const string Title = "Picture Choice (multi selection with other option)";
                                public const FieldType Type = FieldType.PictureChoice;
                                public const bool AllowMultipleSelections = true;
                                public const bool AllowOtherChoice = true;
                                public const string Ref = "sdk_picturechoice_multi_other";

                                public static class Properties
                                {
                                }

                                public static class Choices
                                {
                                    public const string Id1 = "QKeHIPZ40964";
                                    public const string Label1 = "Choice1";

                                    public const string Id2 = "O44YhBEr467O";
                                    public const string Label2 = "Choice2";

                                    public const string Id3 = "QOUmimORgG18";
                                    public const string Label3 = "Choice3";
                                }
                            }

                            public static class YesNo
                            {
                                public const string Id = "uK18t6Dt3tw7";
                                public const string Title = "Yes No";
                                public const FieldType Type = FieldType.YesNo;
                                public const string Ref = "sdk_yesno";

                                public static class Properties
                                {
                                }
                            }

                            public static class Email
                            {
                                public const string Id = "kAkebx9n6XIR";
                                public const string Title = "Email";
                                public const FieldType Type = FieldType.Email;
                                public const string Ref = "sdk_email";

                                public static class Properties
                                {
                                }
                            }

                            public static class OpinionScale
                            {
                                public const string Id = "ViKTN1UFwEwl";
                                public const string Title = "Opinion Scale";
                                public const FieldType Type = FieldType.OpinionScale;
                                public const string Ref = "sdk_opinioncale";

                                public static class Properties
                                {
                                }
                            }

                            public static class Rating
                            {
                                public const string Id = "FHxfo7IZDdrB";
                                public const string Title = "Rating";
                                public const FieldType Type = FieldType.Rating;
                                public const string Ref = "sdk_rating";

                                public static class Properties
                                {
                                }
                            }

                            public static class Date
                            {
                                public const string Id = "q62rc244E7hb";
                                public const string Title = "Date";
                                public const FieldType Type = FieldType.Date;
                                public const string Ref = "sdk_date";

                                public static class Properties
                                {
                                }
                            }

                            public static class Number
                            {
                                public const string Id = "Ip5QFtQ3ezSn";
                                public const string Title = "Number";
                                public const FieldType Type = FieldType.Number;
                                public const string Ref = "sdk_number";

                                public static class Properties
                                {
                                }
                            }

                            public static class Dropdown
                            {
                                public const string Id = "SFYDO4A0sFRM";
                                public const string Title = "Dropdown";
                                public const FieldType Type = FieldType.Dropdown;
                                public const string Ref = "sdk_dropdown";

                                public static class Properties
                                {
                                }
                            }

                            public static class Legal
                            {
                                public const string Id = "VCaJiDfFs74Z";
                                public const string Title = "Legal";
                                public const FieldType Type = FieldType.Legal;
                                public const string Ref = "sdk_legal";

                                public static class Properties
                                {
                                }
                            }

                            public static class FileUpload
                            {
                                public const string Id = "Qrx0o0d14L09";
                                public const string Title = "File Upload";
                                public const FieldType Type = FieldType.FileUpload;
                                public const string Ref = "sdk_fileupload";

                                public static class Properties
                                {
                                }
                            }

                            public static class Website
                            {
                                public const string Id = "ka2570L2lnis";
                                public const string Title = "Website";
                                public const FieldType Type = FieldType.Website;
                                public const string Ref = "sdk_website";

                                public static class Properties
                                {
                                }
                            }

                            public static class Payment
                            {
                                public const string Id = "bXf79h87jhSFD";
                                public const string Title = "Payment";
                                public const FieldType Type = FieldType.Payment;
                                public const string Ref = "sdk_payment";

                                public static class Properties
                                {
                                }
                            }
                        }
                    }

                    public static class Answers
                    {
                        public static class MultipleChoice_Single_Without_Other
                        {
                            public const FormAnswerType Type = FormAnswerType.Choice;

                            public static class Choice
                            {
                                public const string Label = "Choice1";
                            }

                            public static class Field
                            {
                                public const string Id = "b6p0eo5faGz7";
                                public const FieldType Type = FieldType.MultipleChoice;
                                public const string Ref = "sdk_multichoice_single";
                            }
                        }

                        public static class MultipleChoice_Single_With_Other
                        {
                            public const FormAnswerType Type = FormAnswerType.Choice;

                            public static class Choice
                            {
                                public const string Label = "Choice1";
                                public const string Other = "TEXT";
                            }

                            public static class Field
                            {
                                public const string Id = "qIxWIZGIJAV4";
                                public const FieldType Type = FieldType.MultipleChoice;
                                public const string Ref = "sdk_multichoice_single_other";
                            }
                        }

                        public static class MultipleChoice_Multiple_Without_Other
                        {
                            public const FormAnswerType Type = FormAnswerType.Choices;

                            public static class Choices
                            {
                                public static List<string> Labels = new List<string> {"Choice1", "Choice2"};
                            }

                            public static class Field
                            {
                                public const string Id = "hnfaIIwfYdsV";
                                public const FieldType Type = FieldType.MultipleChoice;
                                public const string Ref = "sdk_multichoice_multi";
                            }
                        }

                        public static class MultipleChoice_Multiple_With_Other
                        {
                            public const FormAnswerType Type = FormAnswerType.Choices;

                            public static class Choices
                            {
                                public const string Other = "TEXT";
                                public static List<string> Labels = new List<string> {"Choice1", "Choice2"};
                            }

                            public static class Field
                            {
                                public const string Id = "oy0lMI97wKQG";
                                public const FieldType Type = FieldType.MultipleChoice;
                                public const string Ref = "sdk_multichoice_multi_other";
                            }
                        }

                        public static class PhoneNumber
                        {
                            public const FormAnswerType Type = FormAnswerType.PhoneNumber;
                            public const string Phone_Number = "+12345678900";

                            public static class Field
                            {
                                public const string Id = "jRTzbVFtvj5L";
                                public const FieldType Type = FieldType.PhoneNumber;
                                public const string Ref = "sdk_phonenumber";
                            }
                        }

                        public static class ShortText
                        {
                            public const FormAnswerType Type = FormAnswerType.Text;
                            public const string Text = "TEXT";

                            public static class Field
                            {
                                public const string Id = "o6NXRuJwIouc";
                                public const FieldType Type = FieldType.ShortText;
                                public const string Ref = "sdk_shorttext";
                            }
                        }

                        public static class LongText
                        {
                            public const FormAnswerType Type = FormAnswerType.Text;
                            public const string Text = "TEXT";

                            public static class Field
                            {
                                public const string Id = "hlTuVzJcMt4v";
                                public const FieldType Type = FieldType.LongText;
                                public const string Ref = "sdk_longtext";
                            }
                        }

                        public static class PictureChoice_Single_Without_Other
                        {
                            public const FormAnswerType Type = FormAnswerType.Choice;

                            public static class Choice
                            {
                                public const string Label = "Choice1";
                            }

                            public static class Field
                            {
                                public const string Id = "QbiP5ItH7mAP";
                                public const FieldType Type = FieldType.PictureChoice;
                                public const string Ref = "sdk_picturechoice_single";
                            }
                        }

                        public static class PictureChoice_Single_With_Other
                        {
                            public const FormAnswerType Type = FormAnswerType.Choice;

                            public static class Choice
                            {
                                public const string Label = "Choice1";
                                public const string Other = "TEXT";
                            }

                            public static class Field
                            {
                                public const string Id = "aOCz7ABFtThF";
                                public const FieldType Type = FieldType.PictureChoice;
                                public const string Ref = "sdk_picturechoice_single_other";
                            }
                        }

                        public static class PictureChoice_Multiple_Without_Other
                        {
                            public const FormAnswerType Type = FormAnswerType.Choices;

                            public static class Choices
                            {
                                public static List<string> Labels = new List<string> {"Choice1", "Choice2"};
                            }

                            public static class Field
                            {
                                public const string Id = "fThk3NrYI3DJ";
                                public const FieldType Type = FieldType.PictureChoice;
                                public const string Ref = "sdk_picturechoice_multi";
                            }
                        }

                        public static class PictureChoice_Multiple_With_Other
                        {
                            public const FormAnswerType Type = FormAnswerType.Choices;

                            public static class Choices
                            {
                                public const string Other = "TEXT";
                                public static List<string> Labels = new List<string> {"Choice1", "Choice2"};
                            }

                            public static class Field
                            {
                                public const string Id = "IAFWMalgu2Rz";
                                public const FieldType Type = FieldType.PictureChoice;
                                public const string Ref = "sdk_picturechoice_multi_other";
                            }
                        }

                        public static class YesNo
                        {
                            public const FormAnswerType Type = FormAnswerType.Boolean;
                            public const bool Boolean = true;

                            public static class Field
                            {
                                public const string Id = "uK18t6Dt3tw7";
                                public const FieldType Type = FieldType.YesNo;
                                public const string Ref = "sdk_yesno";
                            }
                        }

                        public static class Email
                        {
                            public const FormAnswerType Type = FormAnswerType.Email;
                            public const string EmailValue = "johndoe@example.com";

                            public static class Field
                            {
                                public const string Id = "kAkebx9n6XIR";
                                public const FieldType Type = FieldType.Email;
                                public const string Ref = "sdk_email";
                            }
                        }

                        public static class OpinionScale
                        {
                            public const FormAnswerType Type = FormAnswerType.Number;
                            public const int Number = 5;

                            public static class Field
                            {
                                public const string Id = "ViKTN1UFwEwl";
                                public const FieldType Type = FieldType.OpinionScale;
                                public const string Ref = "sdk_opinioncale";
                            }
                        }

                        public static class Rating
                        {
                            public const FormAnswerType Type = FormAnswerType.Number;
                            public const int Number = 2;

                            public static class Field
                            {
                                public const string Id = "FHxfo7IZDdrB";
                                public const string Title = "Rating";
                                public const FieldType Type = FieldType.Rating;
                                public const string Ref = "sdk_rating";
                            }
                        }

                        public static class Date
                        {
                            public const FormAnswerType Type = FormAnswerType.Date;
                            public static DateTime DateValue = DateTime.Parse("2000-01-01");

                            public static class Field
                            {
                                public const string Id = "q62rc244E7hb";
                                public const FieldType Type = FieldType.Date;
                                public const string Ref = "sdk_date";
                            }
                        }

                        public static class Number
                        {
                            public const FormAnswerType Type = FormAnswerType.Number;
                            public const int NumberValue = 5;

                            public static class Field
                            {
                                public const string Id = "Ip5QFtQ3ezSn";
                                public const FieldType Type = FieldType.Number;
                                public const string Ref = "sdk_number";
                            }
                        }

                        public static class Dropdown
                        {
                            public const FormAnswerType Type = FormAnswerType.Choice;

                            public static class Choice
                            {
                                public const string Label = "Choice 1";
                            }

                            public static class Field
                            {
                                public const string Id = "SFYDO4A0sFRM";
                                public const FieldType Type = FieldType.Dropdown;
                                public const string Ref = "sdk_dropdown";
                            }
                        }

                        public static class Legal
                        {
                            public const FormAnswerType Type = FormAnswerType.Boolean;
                            public const bool Boolean = true;

                            public static class Field
                            {
                                public const string Id = "VCaJiDfFs74Z";
                                public const FieldType Type = FieldType.Legal;
                                public const string Ref = "sdk_legal";
                            }
                        }

                        public static class FileUpload
                        {
                            public const FormAnswerType Type = FormAnswerType.FileUrl;

                            public const string FileUrl =
                                "https://api.typeform.com/responses/files/eddde18397d2858d055b30eeac59f478406386534120173e799ec512dea155fa/typeform_test";

                            public static class Field
                            {
                                public const string Id = "Qrx0o0d14L09";
                                public const FieldType Type = FieldType.FileUpload;
                                public const string Ref = "sdk_fileupload";
                            }
                        }

                        public static class Website
                        {
                            public const FormAnswerType Type = FormAnswerType.Url;
                            public const string Url = "http://www.example.com";

                            public static class Field
                            {
                                public const string Id = "ka2570L2lnis";
                                public const FieldType Type = FieldType.Website;
                                public const string Ref = "sdk_website";
                            }
                        }

                        public static class Payment
                        {
                            public const FormAnswerType Type = FormAnswerType.Payment;

                            public static class PaymentValue
                            {
                                public const string Amount = "1";
                                public const string Last4 = "1234";
                                public const string Name = "John Doe";
                                public const bool Success = true;
                            }

                            public static class Field
                            {
                                public const string Id = "bXf79h87jhSFD";
                                public const FieldType Type = FieldType.Payment;
                                public const string Ref = "sdk_payment";
                            }
                        }
                    }
                }
            }
        }
    }

    public enum TestEnum
    {
        Test0 = 0,
        Test1 = 1,
        Test2 = 2
    }
}