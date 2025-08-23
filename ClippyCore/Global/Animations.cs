using System;
using System.Collections.Generic;
using System.Text;

namespace ClippyCore.Global
{
    /// <summary>
    /// Keys for the IAgent animation dictionary mapping.
    /// Keys are always bytes.
    /// </summary>
    public static class Animations
    {
        /// <summary>
        /// All animation keys for the Bonzi agent.
        /// </summary>
        public static class Bonzi
        {
            public const byte Acknowledge = 0;
            public const byte Alert = 1;
            public const byte Banana = 2;
            public const byte BananaMiss = 3;
            public const byte Blink = 4;
            public const byte BlowKiss = 5;
            public const byte Butternut = 6;
            public const byte Confused = 7;
            public const byte Congratulate = 8;
            public const byte Decline = 9;
            public const byte DoMagic1 = 10;
            public const byte DoMagic2 = 11;
            public const byte DontRecognize = 12;
            public const byte Explain = 13;
            public const byte Explain2 = 14;
            public const byte Explain3 = 15;
            public const byte Explain4 = 16;
            public const byte GestureDown = 17;
            public const byte GestureLeft = 18;
            public const byte GestureRight = 19;
            public const byte GestureUp = 20;
            public const byte GetAttention = 21;
            public const byte GetAttention2 = 22;
            public const byte GetAttentionContinued = 23;
            public const byte GetAttentionReturn = 24;
            public const byte Giggle = 25;
            public const byte Greet = 26;
            public const byte HandsBehind = 27;
            public const byte HeadphonesContinued = 28;
            public const byte HeadphonesReturn = 29;
            public const byte Hearing1 = 30;
            public const byte Hearing2 = 31;
            public const byte Hearing3 = 32;
            public const byte Hide = 33;
            public const byte HideShow = 34;
            public const byte Hug = 35;
            public const byte Idle1_1 = 36;
            public const byte Idle1_1_2 = 37;
            public const byte Idle1_1_3 = 38;
            public const byte Idle1_11 = 39;
            public const byte Idle1_12 = 40;
            public const byte Idle1_13 = 41;
            public const byte Idle1_14 = 42;
            public const byte Idle1_15 = 43;
            public const byte Idle1_20 = 44;
            public const byte Idle1_21 = 45;
            public const byte Idle1_22 = 46;
            public const byte Idle1_24 = 47;
            public const byte Idle1_25 = 48;
            public const byte Idle1_26 = 49;
            public const byte Idle1_3 = 50;
            public const byte Idle1_4 = 51;
            public const byte Idle1_4_2 = 52;
            public const byte Idle1_5 = 53;
            public const byte Idle1_5_2 = 54;
            public const byte Idle1_6 = 55;
            public const byte Idle1_7 = 56;
            public const byte Idle1_8 = 57;
            public const byte Idle1_9 = 58;
            public const byte Idle1_9_2 = 59;
            public const byte Idle1_9_3 = 60;
            public const byte Idle3_1 = 61;
            public const byte Idle3_2 = 62;
            public const byte Idle3_3 = 63;
            public const byte Juggle = 64;
            public const byte LookDown = 65;
            public const byte LookDownBlink = 66;
            public const byte LookDownLeft = 67;
            public const byte LookDownLeftBlink = 68;
            public const byte LookDownLeftReturn = 69;
            public const byte LookDownReturn = 70;
            public const byte LookDownRight = 71;
            public const byte LookDownRightBlink = 72;
            public const byte LookDownRightReturn = 73;
            public const byte LookLeft = 74;
            public const byte LookLeftBlink = 75;
            public const byte LookLeftReturn = 76;
            public const byte LookRight = 77;
            public const byte LookRightBlink = 78;
            public const byte LookRightReturn = 79;
            public const byte LookUp = 80;
            public const byte LookUpBlink = 81;
            public const byte LookUpLeft = 82;
            public const byte LookUpLeftBlink = 83;
            public const byte LookUpLeftReturn = 84;
            public const byte LookUpReturn = 85;
            public const byte LookUpRight = 86;
            public const byte LookUpRightBlink = 87;
            public const byte LookUpRightReturn = 88;
            public const byte MailCheck = 89;
            public const byte MailCheckEmpty = 90;
            public const byte MailCheckFull = 91;
            public const byte MailNext = 92;
            public const byte MailRead = 93;
            public const byte MailReturn = 94;
            public const byte MoveDown = 95;
            public const byte MoveDownReturn = 96;
            public const byte MoveLeft = 97;
            public const byte MoveLeftReturn = 98;
            public const byte MoveRight = 99;
            public const byte MoveRightReturn = 100;
            public const byte MoveUp = 101;
            public const byte MoveUpReturn = 102;
            public const byte Pleased = 103;
            public const byte PleasedHard = 104;
            public const byte PleasedSoft = 105;
            public const byte Process = 106;
            public const byte Processing = 107;
            public const byte Read = 108;
            public const byte ReadContinued = 109;
            public const byte Reading = 110;
            public const byte ReadLookUp = 111;
            public const byte ReadLookUpContinued = 112;
            public const byte ReadLookUpReturn = 113;
            public const byte ReadReturn = 114;
            public const byte RestPose = 115;
            public const byte Sad = 116;
            public const byte Scout = 117;
            public const byte ScoutAlert = 118;
            public const byte ScoutLeft = 119;
            public const byte ScoutReturn = 120;
            public const byte ScoutRight = 121;
            public const byte Search = 122;
            public const byte Searching = 123;
            public const byte SearchingReturn = 124;
            public const byte Shoosh = 125;
            public const byte Show = 126;
            public const byte StartListening = 127;
            public const byte StopListening = 128;
            public const byte Suggest = 129;
            public const byte SunglassesContinued = 130;
            public const byte SunglassesReturn = 131;
            public const byte Surprised = 132;
            public const byte Think = 133;
            public const byte Thinking = 134;
            public const byte Unbelievable = 135;
            public const byte Uncertain = 136;
            public const byte Wave = 137;
            public const byte Wink = 138;
            public const byte Write = 139;
            public const byte WriteContinued = 140;
            public const byte WriteOnce = 141;
            public const byte WriteOnceAgain = 142;
            public const byte WritePause = 143;
            public const byte WritePre = 144;
            public const byte WriteReturn = 145;
            public const byte Writing = 146;
            public const byte WritingReturn = 147;
        }

        /// <summary>
        /// All animation keys for Shrek agent.
        /// </summary>
        public static class Shrek
        {
            public const byte Back = 0;
            public const byte BeAGoodFriend = 1;
            public const byte BookRead = 2;
            public const byte Burp = 3;
            public const byte BuyTwoAndThird = 4;
            public const byte ByeByeSeeYouNextTime = 5;
            public const byte ChangeYourSettings = 6;
            public const byte CheckYourTukiMail = 7;
            public const byte CleanYourRoom = 8;
            public const byte ClubTuki = 9;
            public const byte DontForgetToEmailYourParents = 10;
            public const byte DownloadMoreThemes = 11;
            public const byte EnterWebAddress = 12;
            public const byte Exit = 13;
            public const byte Farting = 14;
            public const byte FeedYourPet = 15;
            public const byte Forward = 16;
            public const byte GesturingDown = 17;
            public const byte GesturingDownReturn = 18;
            public const byte GesturingLeft = 19;
            public const byte GesturingLeftReturn = 20;
            public const byte GesturingRight = 21;
            public const byte GesturingRightReturn = 22;
            public const byte GesturingUp = 23;
            public const byte GesturingUpReturn = 24;
            public const byte GetSomeHelp = 25;
            public const byte GoodAfternoon = 26;
            public const byte GreatToSeeYouMorning = 27;
            public const byte Hiding = 28;
            public const byte Home = 29;
            public const byte IfYouReallyWantToVisit = 30;
            public const byte IfYouWantToBuyCD = 31;
            public const byte IHopeYouAteBreakfast = 32;
            public const byte ILovegettingEmailDonkey = 33;
            public const byte ILoveGettingEmailRats = 34;
            public const byte LaunchNewWindow = 35;
            public const byte LearnEarnWIn = 36;
            public const byte MovingDown = 37;
            public const byte MovingLeft = 38;
            public const byte MovingReturn = 39;
            public const byte MovingRight = 40;
            public const byte MovingUp = 41;
            public const byte OhYourAWinner = 42;
            public const byte PrintThisPage = 43;
            public const byte ReferAFriend = 44;
            public const byte Refresh = 45;
            public const byte RememberIAmHereToHelp = 46;
            public const byte RememberToBrushYourTeeth = 47;
            public const byte RememberToGiveDadHug = 48;
            public const byte RememberToGiveMomHug = 49;
            public const byte RememberToPickUpToys = 50;
            public const byte RememberToShare = 51;
            public const byte RememberYourParents = 52;
            public const byte Showing = 53;
            public const byte Stop = 54;
            public const byte ToiletFlush = 55;
            public const byte TriviaBathTub = 56;
            public const byte TriviaFairyTale = 57;
            public const byte TriviaMikeMyers = 58;
            public const byte TriviaPeanutButter = 59;
            public const byte TriviaShrekManHours = 60;
            public const byte TriviaWashHair = 61;
            public const byte Tuki = 62;
            public const byte TukiMoola = 63;
            public const byte TukiTukiTuki = 64;
            public const byte TuuuuKiiii = 65;
            public const byte WhatAWonderfulAfternoon = 66;
            public const byte WhatAWonderfulEvening = 67;
            public const byte YourFamilyLovesYou = 68;
        }

        /// <summary>
        /// All animation keys for Clippy agent.
        /// </summary>
        public static class Clippy
        {
            public const byte Alert = 0;
            public const byte CheckingSomething = 1;
            public const byte Congratulate = 2;
            public const byte EmptyTrash = 3;
            public const byte Explain = 4;
            public const byte GestureDown = 5;
            public const byte GestureLeft = 6;
            public const byte GestureRight = 7;
            public const byte GestureUp = 8;
            public const byte GetArtsy = 9;
            public const byte GetAttention = 10;
            public const byte GetTechy = 11;
            public const byte GetWizardy = 12;
            public const byte GoodBye = 13;
            public const byte Greeting = 14;
            public const byte Hearing_1 = 15;
            public const byte Hide = 16;
            public const byte Idle1_1 = 17;
            public const byte IdleAtom = 18;
            public const byte IdleEyeBrowRaise = 19;
            public const byte IdleFingerTap = 20;
            public const byte IdleHeadScratch = 21;
            public const byte IdleRopePile = 22;
            public const byte IdleSideToSide = 23;
            public const byte IdleSnooze = 24;
            public const byte LookDown = 25;
            public const byte LookDownLeft = 26;
            public const byte LookDownRight = 27;
            public const byte LookLeft = 28;
            public const byte LookRight = 29;
            public const byte LookUp = 30;
            public const byte LookUpLeft = 31;
            public const byte LookUpRight = 32;
            public const byte Print = 33;
            public const byte Processing = 34;
            public const byte RestPose = 35;
            public const byte Save = 36;
            public const byte Searching = 37;
            public const byte SendMail = 38;
            public const byte Show = 39;
            public const byte Thinking = 40;
            public const byte Wave = 41;
            public const byte Writing = 42;
        }
    }
}
