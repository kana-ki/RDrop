import { Inject, Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Download } from "../../models/download.model";

@Injectable()
export class AddDownloadService {
    
    public pendingDownloads : Download[] = [];
    private _subscribers : Function[] = [];

    constructor(@Inject("ServiceConfig") private serviceConfig, private http : Http) { }

    public AddDownloadByUrl(url : URL) : void {
        console.debug(`You're adding a download! Using service ${this.serviceConfig.addDownloadUrl}`);
        var download = new Download(url);
        this.NotifySubscribers(download);
    }

    public Subscribe(handler: Function) : void {
        this._subscribers.push(handler);
    }

    private NotifySubscribers(download) : void {
        this._subscribers.forEach(subscriber => subscriber(download));
    }

 }
