import AppUser from "../models/AppUser"

async function Register(){
    

    return(
        <div>
            <div className="map-view">
                
            </div>


            <div className="first-inputs">
                <h3>Where's your neighbourhood</h3>
                <form>
                    <button id="access-location" type="button" onClick={getLocation()}>Get My location</button>
                    <input id="longitude" type="number" step={0.0000000001} placeholder="Longitude"/>
                    <input id="latitude" type="number" step={0.0000000001} placeholder="Latitude"/>
                    <input id="preffered-radius" type="number" step={0.25} placeholder="Preffered Coverage (in km)"/>
                    <button id="edit-coordinates" type="button" onClick={editCoordinates()}></button>
                </form>
            </div>
                

            <div className="second-inputs">
                <h3>Almost there</h3>
                <form>
                    <input id="name" type="text" placeholder="Name"/>
                    <input id="surname" type="text" placeholder="Surname"/>
                    <input id="dob" type="date-picker"/>
                    <input id="gender" type="switch"/>
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

            <button id="switch-views" type="button" onClick={switchViews()}></button>
            <button id="register" type="button" onClick={register()}></button>

        </div>
    );

}

export default Register;