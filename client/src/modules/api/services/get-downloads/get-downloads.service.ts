import { Inject, Injectable } from "@angular/core";
import { Http } from "@angular/http";

@Injectable()
export class GetDownloadsService {
    
    constructor(@Inject("ServiceConfig") private serviceConfig, private http : Http) { }

    public GetDownloads() {
        console.debug(`You're getting downloads! Using service ${this.serviceConfig.getDownloadsUrl}`);
    }

 }
