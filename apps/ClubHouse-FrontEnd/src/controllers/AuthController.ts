import AppUser from "../models/AppUser";
class AuthController{
    constructor(){

    }


    async register(appUser:AppUser){
        const res=await fetch('http://localhost:5156/api/auth/register',{
            method:"POST",
            headers:{"Content-Type":"application/json"},
            body:JSON.stringify(appUser)
        });

        let data=await res.json();
            console.log(data);

        if(res.ok){
            return(data);
        }

        return(`Registration failed: ${data}`);
    }

}

export default AuthController;