import { NgModule } from "@angular/core";
import { Download } from "./models/download.model";
import { AddDownloadService } from './services/add-download/add-download.service';
import { GetDownloadsService } from './services/get-downloads/get-downloads.service';
import { HttpModule } from "@angular/http";
import * as serviceConfig from './service-config.json';

@NgModule({
    declarations: [  ],
    imports: [ HttpModule ],
    exports: [ ],
    providers: [ 
      AddDownloadService, 
      GetDownloadsService,
      { provide: 'ServiceConfig', useValue: serviceConfig }
    ]
  })
export class ApiModule { }