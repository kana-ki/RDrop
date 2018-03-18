import { NgModule } from "@angular/core";
import { ApiServicesModule } from '../api-services/api-services.module';
import { AddDownloadButtonComponent } from './components/add-download-button/add-download-button.component';

@NgModule({
    declarations: [ AddDownloadButtonComponent ],
    imports: [ ApiServicesModule ],
    exports: [ AddDownloadButtonComponent ]
  })
export class ControlsModule { }