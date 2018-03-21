import { DownloadStatus } from './download-status.enum'

export class Download {

    public Status : DownloadStatus;
    public Size : Number;

    constructor(public Url : URL) {
        this.Size = this.GetFileSize();
        this.Status = DownloadStatus.Pending;
        // For show / debug
        setTimeout(() => this.Status = DownloadStatus.Downloading, Math.floor(Math.random() * 10000) + 1)
    }

    private GetFileSize() : Number {
        return 220319911;
    }

    public get ParentUrl() : String {
        var strUrl = this.Url.toString();
        return strUrl.substring(0, strUrl.lastIndexOf('/') + 1);
    }

    public get FileName() : String {
        var strUrl = this.Url.toString();
        return strUrl.substring(strUrl.lastIndexOf('/') + 1);
    }

    public get IsDownloading() : Boolean {
        return this.Status == DownloadStatus.Downloading;
    }

}