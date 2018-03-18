import { NgModule } from "@angular/core";
import { AddDownloadService } from './services/add-download/add-download.service';
import { HttpModule } from "@angular/http";
import * as serviceConfig from './service-config.json';

console.log("This is the serviceConfig: ", serviceConfig);
@NgModule({
    imports: [ HttpModule ],
    providers: [ 
      AddDownloadService, 
      { provide: 'ServiceConfig', useValue: serviceConfig }
    ],
  })
export class ApiServicesModule { }