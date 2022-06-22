export class LoginModel{
    username:string="";
    password:string="";
}

export class SearchModel{
    
    value:string="";
}

export class SongRequestModel{
    page:number=1;
    search:SearchModel=new SearchModel();
}

export class SongModel{
    id:number=0;
    songName:string="";
    artistName:string="";
    songUrl:string="";
    isFavourite:boolean=false;
    categoryId:number=0;
    ratingByUser:number=0;
}