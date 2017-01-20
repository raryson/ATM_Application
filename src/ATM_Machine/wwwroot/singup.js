    buttonRegister = document.querySelector("button");

    buttonRegister.addEventListener('click', function(event){

        event.preventDefault();

        function resetValue(){
            $("input").val("");
        }
        
        var pass1 = document.querySelector("#password").value 
            pass2 = document.querySelector("#password2").value
        if(pass1 === pass2){
            var name =  document.querySelector("#name").value
                age = document.querySelector("#age").value
                email = document.querySelector("#email").value
            //make ajax
                $.ajax({method:"POST",
                url:'/Singup/Register',
                data:{email :email, password: pass1, name: name, age: age},
                statusCode:{
                        201:function(created){
                        alert("Criou com sucesso");
                        window.location = "../Home";
                        },
                        500:function(error){
                        resetValue();
                        alert("Error");
                        },
                        409:function(){
                        resetValue();
                        alert("O email já esta cadastrado");
                        }
                    }
                })
                
        }else{
           var warningPass =  document.querySelector(".alert")
           warningPass.style.display = "block";
           $(".alert").fadeOut(5000);
            
        }
    })