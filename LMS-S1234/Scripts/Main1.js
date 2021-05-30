var container = document.getElementById('form2maincontainer');
console.log(container);

function createCard(name, date, text) {
    var card_row = document.createElement("div");
    card_row.className = 'row';

    var card_str = document.createElement("div");
    card_str.className = 'col-xs-12 col-sm-12 col-md-12';
    card_str.style.paddingTop = '10px';

    var card = document.createElement("div");
    card.className = 'card';
    
    var card_hd = document.createElement("div");
    card_hd.className = 'card-header';
    card_hd.style.backgroundColor = 'sandybrown';



}
