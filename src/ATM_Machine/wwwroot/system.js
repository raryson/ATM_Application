var logout = document.querySelector("#logout");
    modal = document.querySelector("#modal_content");
    withdrawButton = document.querySelector("#withdraw");
    depositButton = document.querySelector("#deposit");
    transferButton = document.querySelector("#transfer");


logout.addEventListener('click', function (event) {
    event.preventDefault();
    
    $.ajax({
        method: "GET",
        url: 'System/Logout',
        statusCode: {
            200: function (created) {
                window.location = "../";
            }
        }
    })
})

withdrawButton.addEventListener('click', function () {
    modal.innerHTML = "<div class='modelator'><h3>Welcome to withdraw mannager</h3><label>Money to be taken: <input type='text' id='valueToWithdraw'/><button id='withdrawgobutton'>Go</button></div>";
    var goWithdraw = document.querySelector('#withdrawgobutton')
    goWithdraw.addEventListener('click', function () {
        var valueToWithdraw = document.querySelector('#valueToWithdraw').value;
        console.log(valueToWithdraw)
        //ajax here
        $.ajax({
            method: "POST",
            url: '/System/Withdraw',
            data: { valueToWithdraw: valueToWithdraw },
            statusCode: {
                201: function () {
                    window.location = "/System";
                },
                500: function (error) {
                    resetValue();
                    alert("Error");
                }
            }
        })

    })
   
})
transferButton.addEventListener('click', function () {
    modal.innerHTML = "<div class='modelator'><h3>Welcome to transfer mannager</h3><label>Email to be transfer: <input type='text' id='emailToTransfer'/></label><label>Money to be transfer: <input type='text' id='valueToTransfer'/><button id='transfergobutton'>Go</button></labe></div>";
    var goTransfer = document.querySelector('#transfergobutton')
    goTransfer.addEventListener('click', function () {
        var valueToTransfer = document.querySelector('#valueToTransfer').value;
            emailToTransfer = document.querySelector('#emailToTransfer').value
        console.log(valueToTransfer, emailToTransfer)
        //ajax here
        $.ajax({
            method: "POST",
            url: '/System/Transfer',
            data: { emailToTransfer: emailToTransfer, valueToTransfer: valueToTransfer},
            statusCode: {
                201: function () {
                    window.location = "/System";
                },
                500: function (error) {
                    alert("Error");
                }
            }
        })
       
    })
})
depositButton.addEventListener('click', function () {
    modal.innerHTML = "<div class='modelator'><h3>Welcome to deposit mannager</h3><label>Money to be deposit: <input type='text' id='valueToDeposit'/><button id='depositgobutton'>Go</button></div>";
    var goDeposit = document.querySelector('#depositgobutton')
    goDeposit.addEventListener('click', function () {
        var valueToDeposit = document.querySelector('#valueToDeposit').value;
            
        console.log(valueToDeposit)
        //ajax here
        $.ajax({
            method: "POST",
            url: '/System/Deposit',
            data: { valueToDeposit: valueToDeposit},
            statusCode: {
                201: function () {
                    window.location = "/System";
                },
                500: function (error) {
                
                    alert("Error");
                }
            }
        })
    })
})

