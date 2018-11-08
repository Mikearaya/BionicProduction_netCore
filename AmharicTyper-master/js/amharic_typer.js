(function ($) {

    var consonants = ["B", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "V", "W", "X", "Y", "Z"];
    var vowels = ["A", "E", "I", "O", "U"];

    var doubleConsonants = ["CH", "GN", "SH", "TS", "ZH"];

    var singleW = ["BWA", "CWA", "DWA", "FWA", "GWA", "HWA", "KWA", "LWA", "MWA", "QWA", "RWA", "SWA", "TWA", "VWA", "ZWA"];
    var doubleW = ["CHWA", "SHWA", "TSWA"];

    var translatorMap = {};

    translatorMap["BA"] = ["ባ", "በ"];
    translatorMap["BE"] = ["ቤ", "በ"];
    translatorMap["BI"] = ["ቢ", "ብ"];
    translatorMap["BO"] = ["ቦ"];
    translatorMap["BU"] = ["ቡ"];
    translatorMap["B"] = ["ብ"];

    translatorMap["CA"] = ["ጫ", "ቻ", "ጨ", "ቸ"];
    translatorMap["CE"] = ["ጬ", "ቼ", "ጨ", "ቸ"];
    translatorMap["CI"] = ["ጪ","ቺ", "ጭ", "ች"];
    translatorMap["CO"] = ["ጮ", "ቾ"];
    translatorMap["CU"] = ["ጩ", "ቹ"];
    translatorMap["C"] = ["ጭ", "ች"];

    translatorMap["DA"] = ["ዳ", "ደ"];
    translatorMap["DE"] = ["ዴ", "ደ"];
    translatorMap["DI"] = ["ዲ", "ድ"];
    translatorMap["DO"] = ["ዶ"];
    translatorMap["DU"] = ["ዱ"];
    translatorMap["D"] = ["ድ"];

    translatorMap["FA"] = ["ፋ", "ፈ"];
    translatorMap["FE"] = ["ፌ", "ፈ"];
    translatorMap["FI"] = ["ፊ", "ፍ"];
    translatorMap["FO"] = ["ፎ"];
    translatorMap["FU"] = ["ፉ"];
    translatorMap["F"] = ["ፍ"];

    translatorMap["GA"] = ["ጋ", "ገ"];
    translatorMap["GE"] = ["ጌ", "ገ"];
    translatorMap["GI"] = ["ጊ", "ግ"];
    translatorMap["GO"] = ["ጎ"];
    translatorMap["GU"] = ["ጉ"];
    translatorMap["G"] = ["ግ"];

    translatorMap["HA"] = ["ሃ", "ሓ", "ሀ", "ሐ"];
    translatorMap["HE"] = ["ሄ", "ሔ"];
    translatorMap["HI"] = ["ሂ", "ሒ", "ህ", "ሕ"];
    translatorMap["HO"] = ["ሆ", "ሖ"];
    translatorMap["HU"] = ["ሁ", "ሑ"];
    translatorMap["H"] = ["ህ", "ሕ"];

    translatorMap["JA"] = ["ጃ", "ጀ"];
    translatorMap["JE"] = ["ጄ", "ጀ"];
    translatorMap["JI"] = ["ጂ", "ጅ"];
    translatorMap["JO"] = ["ጆ"];
    translatorMap["JU"] = ["ጁ"];
    translatorMap["J"] = ["ጅ"];

    translatorMap["KA"] = ["ካ", "ቃ", "ከ", "ቀ"];
    translatorMap["KE"] = ["ቄ", "ኬ", "ከ", "ቀ"];
    translatorMap["KI"] = ["ኪ", "ቂ", "ክ", "ቅ"];
    translatorMap["KO"] = ["ኮ", "ቆ"];
    translatorMap["KU"] = ["ቁ", "ኩ"];
    translatorMap["K"] = ["ክ", "ቅ"];

    translatorMap["LA"] = ["ላ", "ለ"];
    translatorMap["LE"] = ["ሌ", "ለ"];
    translatorMap["LI"] = ["ሊ", "ል"];
    translatorMap["LO"] = ["ሎ"];
    translatorMap["LU"] = ["ሉ"];
    translatorMap["L"] = ["ል"];

    translatorMap["MA"] = ["ማ", "መ"];
    translatorMap["ME"] = ["ሜ", "መ"];
    translatorMap["MI"] = ["ሚ", "ም"];
    translatorMap["MO"] = ["ሞ"];
    translatorMap["MU"] = ["ሙ"];
    translatorMap["M"] = ["ም"];

    translatorMap["NA"] = ["ና", "ነ"];
    translatorMap["NE"] = ["ኔ", "ነ"];
    translatorMap["NI"] = ["ኒ", "ን"];
    translatorMap["NO"] = ["ኖ"];
    translatorMap["NU"] = ["ኑ"];
    translatorMap["N"] = ["ን"];

    translatorMap["PA"] = ["ፓ", "ጳ", "ፐ", "ጰ"];
    translatorMap["PE"] = ["ፔ", "ጴ", "ፐ", "ጰ"];
    translatorMap["PI"] = ["ፒ", "ጲ", "ፕ", "ጵ"];
    translatorMap["PO"] = ["ፖ", "ጶ"];
    translatorMap["PU"] = ["ፑ", "ጱ"];
    translatorMap["P"] = ["ፕ", "ጵ"];

    translatorMap["QA"] = ["ቃ", "ቀ"];
    translatorMap["QE"] = ["ቄ", "ቀ"];
    translatorMap["QI"] = ["ቂ", "ቅ"];
    translatorMap["QO"] = ["ቆ"];
    translatorMap["QU"] = ["ቁ"];
    translatorMap["Q"] = ["ቅ"];

    translatorMap["RA"] = ["ራ", "ረ"];
    translatorMap["RE"] = ["ሬ", "ረ"];
    translatorMap["RI"] = ["ሪ", "ር"];
    translatorMap["RO"] = ["ሮ"];
    translatorMap["RU"] = ["ሩ"];
    translatorMap["R"] = ["ር"];

    translatorMap["SA"] = ["ሳ", "ጻ", "ሣ", "ሰ", "ጸ", "ሠ"];
    translatorMap["SE"] = ["ሴ", "ጼ", "ሤ", "ሰ", "ጸ", "ሠ"];
    translatorMap["SI"] = ["ሲ", "ጺ", "ሢ", "ስ", "ጽ", "ሥ"];
    translatorMap["SO"] = ["ሶ", "ጾ", "ሦ"];
    translatorMap["SU"] = ["ሱ", "ጹ", "ሡ"];
    translatorMap["S"] = ["ስ", "ጽ", "ሥ"];

    translatorMap["TA"] = ["ታ", "ጣ", "ተ", "ጠ"];
    translatorMap["TE"] = ["ቴ", "ጤ", "ተ", "ጠ"];
    translatorMap["TI"] = ["ቲ", "ጢ", "ት", "ጥ"];
    translatorMap["TO"] = ["ቶ", "ጦ"];
    translatorMap["TU"] = ["ቱ", "ጡ"];
    translatorMap["T"] = ["ት", "ጥ"];

    translatorMap["VA"] = ["ቫ", "ቨ"];
    translatorMap["VE"] = ["ቬ", "ቨ"];
    translatorMap["VI"] = ["ቪ", "ቭ"];
    translatorMap["VO"] = ["ቮ"];
    translatorMap["VU"] = ["ቩ"];
    translatorMap["V"] = ["ቭ"];

    translatorMap["WA"] = ["ዋ","ወ"];
    translatorMap["WE"] = ["ዌ", "ወ"];
    translatorMap["WI"] = ["ዊ", "ው"];
    translatorMap["WO"] = ["ዎ"];
    translatorMap["WU"] = ["ዉ"];
    translatorMap["W"] = ["ው"];

    translatorMap["XA"] = ["ሻ", "ሸ"];
    translatorMap["XE"] = ["ሼ", "ሸ"];
    translatorMap["XI"] = ["ሺ", "ሽ"];
    translatorMap["XO"] = ["ሾ"];
    translatorMap["XU"] = ["ሹ"];
    translatorMap["X"] = ["ሽ"];

    translatorMap["YA"] = ["ያ", "የ"];
    translatorMap["YE"] = ["ዬ", "የ"];
    translatorMap["YI"] = ["ይ"];
    translatorMap["YO"] = ["ዮ"];
    translatorMap["YU"] = ["ዩ"];
    translatorMap["Y"] = ["ይ"];

    translatorMap["ZA"] = ["ዛ", "ዣ", "ዘ", "ዠ"];
    translatorMap["ZE"] = ["ዜ", "ዤ", "ዘ", "ዠ"];
    translatorMap["ZI"] = ["ዚ", "ዢ", "ዝ", "ዥ"];
    translatorMap["ZO"] = ["ዞ", "ዦ"];
    translatorMap["ZU"] = ["ዙ", "ዡ"];
    translatorMap["Z"] = ["ዝ", "ዥ"];

    translatorMap["A"] = ["አ", "ኣ"];
    translatorMap["E"] = ["ኤ", "አ"];
    translatorMap["I"] = ["ኢ", "እ"];
    translatorMap["O"] = ["ኦ"];
    translatorMap["U"] = ["ኡ"];

    translatorMap["CHA"] = ["ቻ", "ቸ"];
    translatorMap["CHE"] = ["ቼ", "ቸ"];
    translatorMap["CHI"] = ["ቺ", "ች"];
    translatorMap["CHO"] = ["ቾ"];
    translatorMap["CHU"] = ["ቹ"];
    translatorMap["CH"] = ["ች"];

    translatorMap["SHA"] = ["ሻ", "ሸ"];
    translatorMap["SHE"] = ["ሼ", "ሸ"];
    translatorMap["SHI"] = ["ሺ", "ሽ"];
    translatorMap["SHO"] = ["ሾ"];
    translatorMap["SHU"] = ["ሹ"];
    translatorMap["SH"] = ["ሽ"];

    translatorMap["TSA"] = ["ፃ", "ፀ"];
    translatorMap["TSE"] = ["ፄ", "ፀ"];
    translatorMap["TSI"] = ["ፂ", "ፅ"];
    translatorMap["TSO"] = ["ፆ"];
    translatorMap["TSU"] = ["ፁ"];
    translatorMap["TS"] = ["ፅ"];

    translatorMap["ZHA"] = ["ዣ", "ዠ"];
    translatorMap["ZHE"] = ["ዤ", "ዠ"];
    translatorMap["ZHI"] = ["ዢ", "ዥ"];
    translatorMap["ZHO"] = ["ዦ"];
    translatorMap["ZHU"] = ["ዡ"];
    translatorMap["ZH"] = ["ዥ"];

    translatorMap["GNA"] = ["ኛ", "ኘ"];
    translatorMap["GNE"] = ["ኜ", "ኘ"];
    translatorMap["GNI"] = ["ኒ", "ኝ"];
    translatorMap["GNO"] = ["ኞ"];
    translatorMap["GNU"] = ["ኙ"];
    translatorMap["GN"] = ["ኝ"];

    translatorMap["BWA"] = ["ቧ"];
    translatorMap["CWA"] = ["ቿ", "ጧ"];
    translatorMap["DWA"] = ["ዷ"];
    translatorMap["FWA"] = ["ፏ"];
    translatorMap["GWA"] = ["ጓ"];
    translatorMap["HWA"] = ["ሗ"];
    translatorMap["KWA"] = ["ኳ", "ቋ"];
    translatorMap["LWA"] = ["ሏ"];
    translatorMap["MWA"] = ["ሟ"];
    translatorMap["QWA"] = ["ቋ"];
    translatorMap["RWA"] = ["ሯ"];
    translatorMap["SWA"] = ["ሷ", "ሧ"];
    translatorMap["TWA"] = ["ቷ", "ጧ"];
    translatorMap["VWA"] = ["ቯ"];
    translatorMap["ZWA"] = ["ዟ", "ዧ"];

    translatorMap["CHWA"] = ["ቿ"];
    translatorMap["SHWA"] = ["ሿ"];
    translatorMap["TSWA"] = ["ጿ"];
    translatorMap["GNWA"] = ["ኟ"];
    translatorMap["ZHWA"] = ["ዧ"];

    translatorMap[" "] = ["፡"];
    translatorMap["."] = ["።"];
    translatorMap[","] = ["፣"];
    translatorMap[";"] = ["፤"];
    translatorMap[":"] = ["፥"];
    translatorMap["?"] = ["፧"];


        var maxPosibilities = 8;

    function divideIntoPhonems(str, res, finalRes) {

        if (finalRes.length > maxPosibilities) {
            return;
        }

        var i = 0;
        while (i < str.length) {
            if (i == str.length - 1) {
                res.push(str[i]);
                i++;
            } else if (vowels.includes(str[i])) {
                res.push(str[i]);
                i++;
            } else if (i + 3 < str.length && doubleW.includes(str.substring(i, i + 4))) {
                divideIntoPhonems(str.substring(i + 4), res.concat(str.substring(i, i + 4)), finalRes);
                divideIntoPhonems(str.substring(i + 3), res.concat(str.substring(i, i + 3)), finalRes);
                divideIntoPhonems(str.substring(i + 2), res.concat(str.substring(i, i + 2)), finalRes);
                return

            } else if (i + 2 < str.length && singleW.includes(str.substring(i, i + 3))) {
                divideIntoPhonems(str.substring(i + 3), res.concat(str.substring(i, i + 3)), finalRes);
                divideIntoPhonems(str.substring(i + 1), res.concat(str.substring(i, i + 1)), finalRes);
                return
            } else if (doubleConsonants.includes(str.substring(i, 2 + i))) {
                if (i + 2 < str.length && vowels.includes(str[i + 2])) {
                    divideIntoPhonems(str.substring(i + 3), res.concat(str.substring(i, i + 3)), finalRes)
                }

                divideIntoPhonems(str.substring(i + 2), res.concat(str.substring(i, i + 2)), finalRes);
                divideIntoPhonems(str.substring(i + 1), res.concat(str.substring(i, i + 1)), finalRes);
                return
            } else if (consonants.includes(str[1 + i])) {
                res.push(str[i]);
                i++;
            } else {
                divideIntoPhonems(str.substring(i + 2), res.concat(str.substring(i, i + 2)), finalRes);
                divideIntoPhonems(str.substring(i + 1), res.concat(str.substring(i, i + 1)), finalRes);
                return
            }

        }

        finalRes.push(res);
    }

    function getPossibleFidels(listOfPhonems, res, finalRes) {

        if (finalRes.length > maxPosibilities) {
            return;
        }

        while (listOfPhonems.length != 0) {
            var firstPhonem = listOfPhonems.shift();
            var phonemList = translatorMap[firstPhonem];
            if (null == phonemList || phonemList.length == 0) {

                return
            } else if (phonemList.length > 1) {
                for (var i = 0; i < phonemList.length; i++) {
                    getPossibleFidels(listOfPhonems.slice(), res.concat(phonemList[i]), finalRes)
                }
                return
            } else {
                res.push(phonemList[0]);
            }

        }
        if (res.length != 0) {
            finalRes.push(res);
        }

    }


    function getFidels(input) {

        input = input.replace(/[^A-Za-z]+/g, "");

        if (input.length != 0) {
            input = input.toUpperCase();
            var listOfPhonems = [];
            divideIntoPhonems(input, [], listOfPhonems);

            var posFidelList = [];

            for (var i = 0; i < maxPosibilities && i < listOfPhonems.length; i++) {
                getPossibleFidels(listOfPhonems[i], [], posFidelList)
            }
            var finalRes = [];
            for (var j = 0; j < maxPosibilities && j < posFidelList.length; j++) {
                finalRes.push(posFidelList[j].join(""));
            }
            return finalRes;
        }
        return []
    }


    var $global_fsm_InputEventsEnum = {
        TYPE_AZ: 1,
        TYPE_09: 2,
        TYPE_DOWN_ARROW: 3,
        TYPE_UP_ARROW: 4,
        TYPE_PUNCTUATION: 5,
        TYPE_ENTER: 6,
        TYPE_BACKSPACE: 7,
        TYPE_OTHER: 8,
        ON_FOCUS: 9,
        ON_PASTE: 10,
        ON_CLICK: 11,
        ON_RECEIVE_FIELDS: 12
    };

    function printable(e) {
        switch (e) {
            case $global_fsm_InputEventsEnum.TYPE_AZ:
                return "TYPE_AZ";
                break;
            case $global_fsm_InputEventsEnum.TYPE_09:
                return "TYPE_09";
                break;
            case $global_fsm_InputEventsEnum.TYPE_DOWN_ARROW:
                return "TYPE_DOWN_ARROW";
                break;
            case $global_fsm_InputEventsEnum.TYPE_UP_ARROW:
                return "TYPE_UP_ARROW";
                break;
            case $global_fsm_InputEventsEnum.TYPE_PUNCTUATION:
                return "TYPE_PUNCTUATION";
                break;
            case $global_fsm_InputEventsEnum.TYPE_ENTER:
                return "TYPE_ENTER";
                break;
            case $global_fsm_InputEventsEnum.TYPE_BACKSPACE:
                return "TYPE_BACKSPACE";
                break;
            case $global_fsm_InputEventsEnum.TYPE_OTHER:
                return "TYPE_OTHER";
                break;
            case $global_fsm_InputEventsEnum.ON_FOCUS:
                return "ON_FOCUS";
                break;
            case $global_fsm_InputEventsEnum.ON_PASTE:
                return "ON_PASTE";
                break;
            case $global_fsm_InputEventsEnum.ON_CLICK:
                return "ON_CLICK";
                break;
            case $global_fsm_InputEventsEnum.ON_RECEIVE_FIELDS:
                return "ON_RECEIVE_FIELDS";
                break;
            default:
                console.error("Error in switch case " + e);
                return ""
        }
    }

    var $global_fsm_statesEnum = {
        STATE_IDLE: 1,
        STATE_WRITING_NO_SHOW: 2,
        STATE_WRITING_SHOW: 3
    };

    $.fn.eventManager = function (fsm_event, html_event) {

        switch ($(this).data("$fsm_state")) {
            case $global_fsm_statesEnum.STATE_IDLE:
                $(this).actionOnStateIdle(fsm_event, html_event);
                break;
            case $global_fsm_statesEnum.STATE_WRITING_NO_SHOW:
                $(this).actionOnStateWritingNoShow(fsm_event, html_event);
                break;
            case $global_fsm_statesEnum.STATE_WRITING_SHOW:
                $(this).actionOnStateWritingShow(fsm_event, html_event);
                break;
            default:
                console.log("ERROR in the FSM");
        }
    };


    $.fn.actionOnStateIdle = function (fsm_event, event) {

        console.log("received event " + printable(fsm_event) + " on state idle");

        var k = null != event && (event.type == "keydown" || event.type == "keypress") ? event.keyCode || event.charCode: "";

        switch (fsm_event) {
            case $global_fsm_InputEventsEnum.TYPE_AZ:
                $(this).data("$fsm_string_processed", String.fromCharCode(k));
                $(this).data("$fsm_state", $global_fsm_statesEnum.STATE_WRITING_NO_SHOW);
                this.doApiQuery();
                break;

            case $global_fsm_InputEventsEnum.TYPE_PUNCTUATION:
                if (this.isPunctuationTranslated()) {
                    this.writeInInput("", String.fromCharCode(k));
                    event.preventDefault();
                }
                break;

            case $global_fsm_InputEventsEnum.TYPE_09:
            case $global_fsm_InputEventsEnum.TYPE_DOWN_ARROW:
            case $global_fsm_InputEventsEnum.TYPE_UP_ARROW:
            case $global_fsm_InputEventsEnum.TYPE_ENTER:
            case $global_fsm_InputEventsEnum.TYPE_BACKSPACE:
            case $global_fsm_InputEventsEnum.TYPE_OTHER:
            case $global_fsm_InputEventsEnum.ON_FOCUS:
            case $global_fsm_InputEventsEnum.ON_PASTE:
            case $global_fsm_InputEventsEnum.ON_CLICK:
            case $global_fsm_InputEventsEnum.ON_RECEIVE_FIELDS:
                $(this).data("$fsm_string_processed", "");
                break;

            default:
                $(this).data("$fsm_string_processed", "");
                console.error("Error in the FSM. untreated event " + printable(fsm_event) + " in state IDLE");
                break

        }
    };

    $.fn.actionOnStateWritingNoShow = function (fsm_event, event) {

        console.log("received event " + printable(fsm_event) + " on state Writing No Show");

        var k = null != event && (event.type == "keydown" || event.type == "keypress") ? event.keyCode || event.charCode : "";

        switch (fsm_event) {
            case $global_fsm_InputEventsEnum.TYPE_AZ:
                $(this).data("$fsm_string_processed", $(this).data("$fsm_string_processed") + String.fromCharCode(k));
                this.doApiQuery();
                break;

            case $global_fsm_InputEventsEnum.TYPE_BACKSPACE:
                $(this).data("$fsm_string_processed", $(this).data("$fsm_string_processed").substring(0, $(this).data("$fsm_string_processed").length - 1));
                this.doApiQuery();
                break;

            case $global_fsm_InputEventsEnum.TYPE_DOWN_ARROW:
            case $global_fsm_InputEventsEnum.TYPE_UP_ARROW:
                break;

            case $global_fsm_InputEventsEnum.ON_RECEIVE_FIELDS:
                $(this).data("$fsm_state", $global_fsm_statesEnum.STATE_WRITING_SHOW);
                this.showDropdown();
                break;

            case $global_fsm_InputEventsEnum.TYPE_PUNCTUATION:
                $(this).data("$fsm_state", $global_fsm_statesEnum.STATE_IDLE);
                $(this).data("$fsm_string_processed", "");
                if (this.isPunctuationTranslated()) {
                    this.writeInInput("", String.fromCharCode(k));
                    event.preventDefault();
                }
                break;

            case $global_fsm_InputEventsEnum.TYPE_09:
            case $global_fsm_InputEventsEnum.TYPE_ENTER:
            case $global_fsm_InputEventsEnum.TYPE_OTHER:
            case $global_fsm_InputEventsEnum.ON_FOCUS:
            case $global_fsm_InputEventsEnum.ON_PASTE:
            case $global_fsm_InputEventsEnum.ON_CLICK:
                $(this).data("$fsm_state", $global_fsm_statesEnum.STATE_IDLE);
                $(this).data("$fsm_string_processed", "");
                break;

            default:
                $(this).data("$fsm_state", $global_fsm_statesEnum.STATE_IDLE);
                $(this).data("$fsm_string_processed", "");
                console.error("Error in the FSM. untreated event " + printable(fsm_event) + " in state IDLE");
                break
        }
    };

    $.fn.actionOnStateWritingShow = function (fsm_event, event) {

        console.log("received event " + printable(fsm_event) + " on state Writing Show");

        var k = null != event && (event.type == "keydown" || event.type == "keypress") ? event.keyCode || event.charCode : "";

        switch (fsm_event) {
            case $global_fsm_InputEventsEnum.TYPE_AZ:
                $(this).data("$fsm_state", $global_fsm_statesEnum.STATE_WRITING_NO_SHOW);
                this.hideDropdown();
                $(this).data("$fsm_string_processed", $(this).data("$fsm_string_processed") + String.fromCharCode(k));
                this.doApiQuery();
                break;

            case $global_fsm_InputEventsEnum.TYPE_09:
                $(this).data("$fsm_state", $global_fsm_statesEnum.STATE_IDLE);
                this.choseDropdownOption(String.fromCharCode(k));
                $(this).data("$fsm_string_processed", "");
                this.hideDropdown();
                event.preventDefault();
                break;

            case $global_fsm_InputEventsEnum.TYPE_DOWN_ARROW:
                this.moveSelectedDropdownOption(true);
                event.preventDefault();
                break;

            case $global_fsm_InputEventsEnum.TYPE_UP_ARROW:
                this.moveSelectedDropdownOption(false);
                event.preventDefault();
                break;

            case $global_fsm_InputEventsEnum.TYPE_PUNCTUATION:
                $(this).data("$fsm_state", $global_fsm_statesEnum.STATE_IDLE);
                this.choseSelectedDropdownOption(String.fromCharCode(k));
                $(this).data("$fsm_string_processed", "");
                this.hideDropdown();
                this.resetData();
                event.preventDefault();
                break;

            case $global_fsm_InputEventsEnum.TYPE_ENTER:
                $(this).data("$fsm_state", $global_fsm_statesEnum.STATE_IDLE);
                this.choseSelectedDropdownOption("");
                $(this).data("$fsm_string_processed", "");
                this.hideDropdown();
                this.resetData();
                event.preventDefault();
                break;

            case $global_fsm_InputEventsEnum.TYPE_BACKSPACE:
                this.hideDropdown();
                $(this).data("$fsm_string_processed", $(this).data("$fsm_string_processed").substring(0, $(this).data("$fsm_string_processed").length - 1));
                if ($(this).data("$fsm_string_processed").length > 0) {
                    $(this).data("$fsm_state", $global_fsm_statesEnum.STATE_WRITING_NO_SHOW);
                    this.doApiQuery();
                }
                else {
                    $(this).data("$fsm_state", $global_fsm_statesEnum.STATE_IDLE);
                    $(this).data("$fsm_string_processed", "");
                }
                break;

            case $global_fsm_InputEventsEnum.ON_RECEIVE_FIELDS:
                console.error("Received fields while FSM was displaying data... whaaaat?");
                break;

            case $global_fsm_InputEventsEnum.TYPE_OTHER:
            case $global_fsm_InputEventsEnum.ON_FOCUS:
            case $global_fsm_InputEventsEnum.ON_PASTE:
            case $global_fsm_InputEventsEnum.ON_CLICK:
                $(this).data("$fsm_state", $global_fsm_statesEnum.STATE_IDLE);
                $(this).data("$fsm_string_processed", "");
                this.hideDropdown();
                break;

            default:
                console.error("Error in the FSM. untreated event " + printable(fsm_event) + " in state IDLE");
                $(this).data("$fsm_state", $global_fsm_statesEnum.STATE_IDLE);
                $(this).data("$fsm_string_processed", "");
                this.hideDropdown();
                break;
        }
    };


    $.fn.doApiQuery = function () {

        console.log("entering doApiQuery");

        if ($(this).data("$fsm_string_processed").length > 0) {

            var response = getFidels($(this).data("$fsm_string_processed"));
            $(this).data("$fsm_list_fidels", response);
            console.log($(this).data("$fsm_list_fidels"));
            $(this).eventManager($global_fsm_InputEventsEnum.ON_RECEIVE_FIELDS, null)
        }
    };


    $.fn.showDropdown = function () {
        console.log("show dropdown");
        $(this).data("$fsm_list_fidels_selected_index", 0);

        var l = $(this).data("$fsm_list_fidels");
        var drop = $(this).next("div.dropdown").find("div.dropdown-content");
        drop.empty();
        drop.show();
        $.each(l, function (index, value) {
            var idx = index < 9 ? index + 1 + ". " : "&nbsp;&nbsp;&nbsp;";
            drop.append("<span data-idx='" + index + "'>" + idx + value + "</span>");
        });
        this.highlightSelectionInDropdown();
    };

    $.fn.hideDropdown = function () {
        console.log("hide dropdown");
        $(this).data("$fsm_list_fidels_selected_index", 0);

        var l = $(this).data("$fsm_list_fidels");
        var drop = $(this).next("div.dropdown").find("div.dropdown-content");
        drop.empty();
        drop.hide();
        this.resetData();
    };

    $.fn.moveSelectedDropdownOption = function (b) {
        var l = $(this).data("$fsm_list_fidels").length;
        var idx = $(this).data("$fsm_list_fidels_selected_index");

        if (b) {
            idx += 1;
        } else {
            idx -= 1;
        }
        $(this).data("$fsm_list_fidels_selected_index", (l + idx) % l);
        console.log("index at " + $(this).data("$fsm_list_fidels_selected_index"));
        this.highlightSelectionInDropdown();
    };

    $.fn.highlightSelectionInDropdown = function () {
        var d = $(this).data("$fsm_list_fidels_selected_index");
        var drop = $(this).next("div.dropdown").find("div.dropdown-content");
        drop.find("span").removeClass("selected");
        drop.find("span[data-idx='" + d + "']").addClass("selected");
    };

    $.fn.choseSelectedDropdownOption = function (punctuation) {
        this.writeInInput($(this).data("$fsm_list_fidels")[$(this).data("$fsm_list_fidels_selected_index")], punctuation);
        console.log("punctuation/enter on dropdown")
    };

    $.fn.choseDropdownOption = function (index) {
        if (index != 0) {
            var idx = ($(this).data("$fsm_list_fidels").length < index ? $(this).data("$fsm_list_fidels").length - 1 : index - 1);
            this.writeInInput($(this).data("$fsm_list_fidels")[idx], "");
        }
        console.log("Choose dropdown " + index)
    };

    $.fn.isPunctuationTranslated = function (){

        return $(this).hasClass("amharic-punctuation");
    };

    $.fn.getPunctuation = function (pct){

        if (this.isPunctuationTranslated() && pct in translatorMap)
            return translatorMap[pct];

        return pct;
    };

    $.fn.writeInInput = function (str, punctuation) {
        var v = this.val();
        var pos = this[0].selectionStart;

        v = v.substring(0, pos - $(this).data("$fsm_string_processed").length) + str + this.getPunctuation(punctuation) + v.substring(pos, v.length);
        this.val(v);
        this.selectRange(pos - $(this).data("$fsm_string_processed").length + str.length + this.getPunctuation(punctuation).length);
    };

    $.fn.selectRange = function (pos) {
        return this.each(function () {
            if ('selectionStart' in this) {
                this.selectionStart = pos;
                this.selectionEnd = pos;
            } else if (this.setSelectionRange) {
                this.setSelectionRange(pos, pos);
            } else if (this.createTextRange) {
                var range = this.createTextRange();
                range.collapse(true);
                range.moveEnd('character', pos);
                range.moveStart('character', pos);
                range.select();
            }
        });
    };

    $.fn.resetData = function () {
        $(this).data("$fsm_list_fidels_selected_index", 0);
        $(this).data("$fsm_list_fidels", []);
    };

    $.fn.onDropdownClick = function () {
        console.log("click on dropdown");
        var idx = this.data("idx");
        var $_fidel_input = this.parent().parent().siblings("input");
        $_fidel_input.choseDropdownOption(idx + 1);
        $_fidel_input.hideDropdown();
        $_fidel_input.focus();
    };

    $(function () {

        var $_fidelInput = $("input.amharic-typer");

        $_fidelInput.after($("<div>").addClass("dropdown").append($("<div>").addClass("dropdown-content")));

        $("div.dropdown-content").on('click', 'span', function () {
            $(this).onDropdownClick();
        });

        $_fidelInput.click(function (event) {
            $(this).eventManager($global_fsm_InputEventsEnum.ON_CLICK, event);
        });

        $_fidelInput.data("$fsm_state", $global_fsm_statesEnum.STATE_IDLE);
        $_fidelInput.data("$fsm_string_processed", "");
        $_fidelInput.data("$fsm_list_fidels", []);
        $_fidelInput.data("$fsm_list_fidels_selected_index", 0);

        $_fidelInput.on("focus", function (event) {
            $(this).eventManager($global_fsm_InputEventsEnum.ON_FOCUS, event);
        });

        $_fidelInput.on("keydown", function (event) {
            var key = event.keyCode;

            if (key == 8) {
                $(this).eventManager($global_fsm_InputEventsEnum.TYPE_BACKSPACE, event);
            }
            else if (key == 38) {
                $(this).eventManager($global_fsm_InputEventsEnum.TYPE_UP_ARROW, event);
            }
            else if (key == 40) {
                $(this).eventManager($global_fsm_InputEventsEnum.TYPE_DOWN_ARROW, event);
            }
            // key right, left, ESC
            else if (key == 37 || key == 39 || key == 27) {
                $(this).eventManager($global_fsm_InputEventsEnum.TYPE_OTHER, event);
            }
        });

        $_fidelInput.on("keypress", function (event) {
            var key = event.keyCode || event.charCode;

            if (key >= 48 && key <= 57) {
                $(this).eventManager($global_fsm_InputEventsEnum.TYPE_09, event);
            }
            else if ((key >= 65 && key <= 90) || (key >= 97 && key <= 122)) {
                $(this).eventManager($global_fsm_InputEventsEnum.TYPE_AZ, event);
            }
            //            space        comma       point         colon    semi-colon    question-mark
            else if (key == 32 || key == 44 || key == 46 || key == 58 || key == 59 || key == 63){
                $(this).eventManager($global_fsm_InputEventsEnum.TYPE_PUNCTUATION, event);
            }
            else if (key == 13) {
                $(this).eventManager($global_fsm_InputEventsEnum.TYPE_ENTER, event);
            }
            else if (key == 8) {
                //nothing;
                // On firefox, the backspace event is raised twice
            }
            else {
                $(this).eventManager($global_fsm_InputEventsEnum.TYPE_OTHER, event);
            }

        });

        $_fidelInput.on("paste", function () {
            $(this).eventManager($global_fsm_InputEventsEnum.ON_PASTE, event)
        });


    });

})(jQuery);
