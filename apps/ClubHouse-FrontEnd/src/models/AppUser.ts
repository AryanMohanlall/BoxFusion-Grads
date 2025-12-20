class AppUser{
     Email:string;
     UserName:string;
     Password:string;
     Name:string;
     Surname:string;
     DOB:Date;
     IsMale:boolean;
     Longitude:number;
     Latitude:number;
     PrefferedRadiusKm:number;
     PrefferedCategories:string;
     AcceptedTermsAndConditions:boolean;

    constructor(
        Email:string,
        UserName:string,
        Password:string,
        Name:string,
        Surname:string,
        DOB:Date,
        IsMale:boolean,
        Longitude:number,
        Latitude:number,
        PrefferedRadiusKm:number,
        PrefferedCategories:string,
        AcceptedTermsAndConditions:boolean,
    ){
        this.Email=Email;
        this.UserName=UserName;
        this.Password=Password;
        this.Name=Name;
        this.Surname=Surname;
        this.DOB=DOB;
        this.IsMale=IsMale;
        this.Longitude=Longitude;
        this.Latitude=Latitude;
        this.PrefferedRadiusKm=PrefferedRadiusKm;
        this.PrefferedCategories=PrefferedCategories;
        this.AcceptedTermsAndConditions=AcceptedTermsAndConditions;
    }

}

export default AppUser;