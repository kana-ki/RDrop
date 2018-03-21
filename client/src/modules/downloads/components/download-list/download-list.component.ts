import { Component, Input } from "@angular/core";
import { DownloadStatus } from "modules/api/models/download-status.enum";
import { Download } from "modules/api/models/download.model";
import { AddDownloadService } from "modules/api/services/add-download/add-download.service";

@Component({
    selector: 'download-list',
    templateUrl: './download-list.template.html',
    styleUrls: [ './download-list.style.scss' ]
})
export class DownloadListComponent {
    
    private _downloads : Download[] = [];

    constructor(addDownloadService : AddDownloadService) {
        addDownloadService.Subscribe(download => this.OnDownloadAdded(download));
    }

    private OnDownloadAdded(download : Download) : void {
        this._downloads.push(download);
        console.debug(`Adding download ${download.Url} to downloads list.`)
    }

}
