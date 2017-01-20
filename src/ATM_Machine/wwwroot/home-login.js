var buttonLogin = document.querySelector('button');
    buttonLogin.addEventListener('click', function(event){
        event.preventDefault();

        var valueEmail = document.querySelector('#email').value;
            valuePassword = document.querySelector('#password').value;
            //make ajax
            function resetValue(){
                 $("input").val("");
             }
                $.ajax({method:"POST",
                url:'/Home/Login',
                data:{email :valueEmail, password: valuePassword},
                statusCode:{
                        200:function(){
                        window.location = "/System";
                        },
                        500:function(error){
                        resetValue();
                        alert("Error");
                        },
                        403:function(){
                        resetValue();
                        alert("Wrong");
                        }
                    }
                })

    })