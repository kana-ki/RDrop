import { NgModule } from "@angular/core";
import { ApiModule } from '../api/api.module';
import { ControlsModule } from '../controls/controls.module';
import { AddDownloadButtonComponent } from './components/add-download-button/add-download-button.component';
import { DownloadItemComponent } from './components/download-item/download-item.component';

@NgModule({
    declarations: [ DownloadItemComponent, AddDownloadButtonComponent ],
    imports: [ ApiModule, ControlsModule ],
    exports: [ DownloadItemComponent, AddDownloadButtonComponent ]
  })
export class DownloadsModule { }