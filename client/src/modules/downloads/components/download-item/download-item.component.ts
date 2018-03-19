import { Component, Input } from "@angular/core";
import { DownloadStatus } from "./download-item-status.enum";

@Component({
    selector: 'download-item',
    templateUrl: './download-item.template.html',
    styleUrls: [ './download-item.style.scss' ]
})
export class DownloadItemComponent {
    
    @Input('url') public Url : String;
    public get ParentUrl() : String {
        return this.Url.substring(0, this.Url.lastIndexOf('/') + 1);
    }
    public get FileName() : String {
        return this.Url.substring(this.Url.lastIndexOf('/') + 1);
    }

    @Input('size') public Size : Number;
    @Input('status') public Status : DownloadStatus
    public get IsDownloading() : Boolean {
        return this.Status == DownloadStatus.Downloading;
    }

    constructor() {
        this.Url = "https://my.maxium.server.io/long/really/long/super/path/vscode_installer.exe"
        this.Size = 34816;
        // this.Status = DownloadStatus.Downloading;
    }

}
