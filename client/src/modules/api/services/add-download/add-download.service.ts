import { Inject, Injectable } from "@angular/core";
import { Http } from "@angular/http";

@Injectable()
export class AddDownloadService {
    
    constructor(@Inject("ServiceConfig") private serviceConfig, private http : Http) { }

    public AddDownloadByUrl() {
        alert(`You're adding a download! Using service ${this.serviceConfig.addDownloadUrl}`);
    }

 }
