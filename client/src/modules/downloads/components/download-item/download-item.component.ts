import { Component, Input } from "@angular/core";
import { DownloadStatus } from "modules/api/models/download-status.enum";
import { Download } from "modules/api/models/download.model";

@Component({
    selector: 'download-item',
    templateUrl: './download-item.template.html',
    styleUrls: [ './download-item.style.scss' ]
})
export class DownloadItemComponent {
    
    @Input('download') private _download : Download;

}
