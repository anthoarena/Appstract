// JavaScript source code
let yourUrl = "https://localhost:44374/api/Contest/contestant";
let page;

function CreateContestant(first, last, email, sn, birthdate) {

    var xhr = new XMLHttpRequest();
    xhr.open("POST", yourUrl, true);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.setRequestHeader('Access-Control-Allow-Origin', '*');
    xhr.setRequestHeader('Access-Control-Allow-Methods', 'GET, POST, PATCH, PUT, DELETE, OPTIONS');
    xhr.setRequestHeader('Access-Control-Allow-Headers', 'Origin, Content-Type, X-Auth-Token');
    xhr.send(JSON.stringify({
        firstname: first.value,
        lastname: last.value,
        email: email.value,
        serialNumber: sn.value,
        birthdate: birthdate.value
    }));

    
    xhr.onload = function () {
        var jsonResponse = JSON.parse(xhr.responseText);
        if (JSON.stringify(jsonResponse.errors).length == 0)
            alert(JSON.stringify(jsonResponse.errors));
        else
            alert(jsonResponse.message);
    };

}

function AllParticipants() {
    page = 1;

    var url = yourUrl + "?PageNumber=" + page + "&PageSize=10";
    fetch(url).then(
        res => {
            res.json().then(
                data => {

                    var temp = "";
                    data.forEach((itemData) => {
                        temp += "<tr>";
                        temp += "<td>" + itemData.firstname + "</td>";
                        temp += "<td>" + itemData.lastname + "</td>";
                        temp += "<td>" + itemData.email + "</td>";
                        temp += "<td>" + itemData.serialNumber + "</td>" +
                            "</tr>";
                    });
                    document.getElementById('data').innerHTML = temp;

                }
            )
        }
    );
}

function NextPage() {
    page += 1;
    var url = yourUrl + "?PageNumber=" + page + "&PageSize=10";
    fetch(url).then(
        res => {
            res.json().then(
                data => {

                    var temp = "";
                    data.forEach((itemData) => {
                        temp += "<tr>";
                        temp += "<td>" + itemData.firstname + "</td>";
                        temp += "<td>" + itemData.lastname + "</td>";
                        temp += "<td>" + itemData.email + "</td>";
                        temp += "<td>" + itemData.serialNumber + "</td>" +
                            "</tr>";
                    });
                    document.getElementById('data').innerHTML = temp;

                }
            )
        }
    );

}


function PreviousPage() {
    page -= 1;

    if (page < 1)
        page = 1;

    var url = yourUrl + "?PageNumber=" + page + "&PageSize=10";
    fetch(url).then(
        res => {
            res.json().then(
                data => {

                    var temp = "";
                    data.forEach((itemData) => {
                        temp += "<tr>";
                        temp += "<td>" + itemData.firstname + "</td>";
                        temp += "<td>" + itemData.lastname + "</td>";
                        temp += "<td>" + itemData.email + "</td>";
                        temp += "<td>" + itemData.serialNumber + "</td>" +
                            "</tr>";
                    });
                    document.getElementById('data').innerHTML = temp;

                }
            )
        }
    );

}
