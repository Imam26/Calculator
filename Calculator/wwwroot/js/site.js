$(document).ready(function () {
    var entry = "";
    var operators = ["+", "-", "/", "*", "^"];

    $("button[type='button']").click(function () {
        entry = $(this).attr("value");  
        let textareaVal = $("#display").val();   

        $(".ErrorMessage").val("");
        
        if (entry == "ce") {
            textareaVal = textareaVal.slice(0, -1)
        } else if (entry == "ac") {
            textareaVal = "";            
            $(".Parameter").val('')
        } else if (entry == '(') {
            let lastChar = textareaVal.substr(textareaVal.length - 1);
            if (/^[0-9]+$/.test(lastChar)) {
                textareaVal += "*";
            }
            textareaVal += entry;
        } else if (entry == ')') {
            if ((textareaVal.match(/[(]/g) || []).length > (textareaVal.match(/[)]/g) || []).length ) {
                textareaVal += entry;
            }
        } else if (operators.indexOf(entry) != -1) {
            let lastChar = textareaVal.substr(textareaVal.length - 1);
            if (operators.indexOf(lastChar) != -1 && textareaVal.length > 1) {                
                textareaVal = textareaVal.slice(0, -1);
                if (textareaVal.substr(textareaVal.length - 1) == "(") {
                    entry = lastChar;
                }
                textareaVal += entry;
            } else if (/^[0-9]+$/.test(lastChar) || lastChar == '!' || lastChar == ')' || lastChar == 'x' || lastChar == 'y' || lastChar == 'z') {
                textareaVal += entry;
            } else if (entry == '-' && (textareaVal == "" || lastChar == "(")) {
                textareaVal += entry;
            }

        } else if (entry != "=") {                        
            textareaVal += entry;            
        } 

        $("#display").val(textareaVal);
        $("#display").html(textareaVal);
    });

});