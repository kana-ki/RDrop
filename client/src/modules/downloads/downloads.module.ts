import { NgModule } from "@angular/core";
import { ApiModule } from '../api/api.module';
import { ControlsModule } from '../controls/controls.module';
import { AddDownloadButtonComponent } from './components/add-download-button/add-download-button.component';
import { DownloadItemComponent } from './components/download-item/download-item.component';
import { DownloadListComponent } from "./components/download-list/download-list.component";
import { CommonModule } from "@angular/common";

@NgModule({
    declarations: [ DownloadListComponent, DownloadItemComponent, AddDownloadButtonComponent ],
    imports: [ CommonModule, ApiModule, ControlsModule ],
    exports: [ DownloadListComponent, DownloadItemComponent, AddDownloadButtonComponent ]
  })
export class DownloadsModule { }