let logs = [];
let currentIndex = 0;

function checkUpdates() {
    alert("new updates");
}


function showHint(str) {
    if (str.length == 0) {
        document.getElementById("txtHint").innerHTML = "";
        return;
    } else {
        var xmlhttp = new XMLHttpRequest();
        xmlhttp.onreadystatechange = function() {
            if (this.readyState == 4 && this.status == 200) {
                devs = JSON.parse(this.responseText);
                let p = ""
                devs.forEach(dev => {
                    if (dev.skills.indexOf(str) >= 0) p = p + "<p>" + dev.name + " | " 
                    + dev.age + " | " + dev.skills+  "</p>";
                })
                document.getElementById("txtHint").innerHTML = p;
            }
        };
        xmlhttp.open("GET", "getDev.php?q=" + str, true);
        xmlhttp.send();
    }

}