import AppUser from "../models/AppUser";
import AuthController from "../controllers/AuthController";
import LocationController from "../controllers/LocationController"
import { useState } from "react";

function Register(){
    //States
    const [currentView,setCurrentView]=useState(3);
    const [canEditCordinates,setcanEditCordinates]=useState(false);
    

    //Objects(variables)
    let authManager:AuthController=new AuthController();
    let locationManager:LocationController=new LocationController();


    //Methods
    function buildUser(){
        let newUser = new AppUser(
            (document.getElementById('email') as HTMLInputElement).value.trim(),
            (document.getElementById('username') as HTMLInputElement).value.trim(),
            (document.getElementById('password') as HTMLInputElement).value.trim(),
            (document.getElementById('name') as HTMLInputElement).value.trim(),
            (document.getElementById('surname') as HTMLInputElement).value.trim(),
            new Date((document.getElementById('dob') as HTMLInputElement).value),
            (document.getElementById('gender') as HTMLInputElement).checked,
            parseFloat((document.getElementById('longitude') as HTMLInputElement).value),
            parseFloat((document.getElementById('latitude') as HTMLInputElement).value),
            parseFloat((document.getElementById('preffered-radius') as HTMLInputElement).value),
            (document.getElementById('preffered-categories') as HTMLInputElement).value,
            true
        );

        return newUser;
    }

    //Go to the previous view
    function prev(){
        if(currentView==0){
            return;
        }
        setCurrentView(currentView-1)
    }

    //Go to the next view
    async function next(){
        if(currentView>2){
            let user=buildUser();
            let res= await authManager.register(user);
            console.log("Login attempted")
            console.log(res);
        }
        else{
            setCurrentView(currentView+1);
        }
    }

    //Enable/disable geocordinates editing
    function editCordinates(){
        if(canEditCordinates){
            setcanEditCordinates(!canEditCordinates)
        }
    }



    //Return the component
    return(
        <div>
            <div className="map-view">
                
            </div>

            <div className="first-inputs">
                <h3>Where's your neighbourhood</h3>
                <form>
                    <button id="access-location" type="button" onClick={()=> locationManager.getLocation()}>Get My location</button>
                    <input id="longitude" type="number" step={0.0000000001} placeholder="Longitude"/>
                    <input id="latitude" type="number" step={0.0000000001} placeholder="Latitude"/>
                    <input id="preffered-radius" type="number" step={0.25} placeholder="Preffered Coverage (in km)"/>
                    <button id="edit-coordinates" type="button" onClick={editCordinates}>Edit Cordinates</button>
                </form>
            </div>

            <div className="second-inputs">
                <h3>Almost there</h3>
                <form>
                    <input id="name" type="text" placeholder="Name"/>
                    <input id="surname" type="text" placeholder="Surname"/>
                    <input id="preffered-categories" type="text" placeholder="Preffered categories"/>
                    
                    <input id="dob" type="date"/>
                    <input id="gender" type="checkbox"/>
                </form>
            </div>

            <div className="third-inputs">
                <h3>Final Step</h3>
                <form>
                    <input id="username" type="text" placeholder="Username"/>
                    <input id="email" type="email" placeholder="Email address"/>
                    <input id="password" type="password" placeholder="Password"/>
                    <input id="confirm-password" type="password" placeholder="Confirm Password"/>
                </form>
            </div>

            <button id="switch-views" type="button" onClick={prev}>Prev</button>
            <button id="register" type="button" onClick={next}>Next</button>

        </div>
    );

    

}

export default Register;