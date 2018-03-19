import { Component } from "@angular/core";
import { AddDownloadService } from "../../../api/services/add-download/add-download.service";

@Component({
    selector: 'add-download-button',
    templateUrl: './add-download-button.template.html',
    styleUrls: [ './add-download-button.style.scss' ]
})
export class AddDownloadButtonComponent {

    constructor (private addDownloadService : AddDownloadService) { }

    public AddDownload() {
        this.addDownloadService.AddDownloadByUrl();
    }

 }
