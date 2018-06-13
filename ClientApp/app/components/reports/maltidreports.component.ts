import { Component, Inject, Input, OnChanges, SimpleChange, SimpleChanges } from '@angular/core';
import { Http } from '@angular/http';
import { CategoriesComponent } from '../categories/categories.component';
import { GroupsComponent } from '../groups/groups.component';
import { ReportDateComponent } from '../reportdate/reportdate.component';

@Component({
    selector: 'reports',
    templateUrl: './maltidreports.component.html',
})

export class MaltidReportsComponent {
    public reports: MaltidReport[];

    http: Http;
    baseUrl: string;

    @Input() group: string;
    @Input() reportdate: string;

    @Input() categories: CategoriesComponent;
//    @Input() groups: GroupsComponent;
//    @Input() reportdate: ReportDateComponent;
    

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http; this.baseUrl = baseUrl;
//        http.get(baseUrl + 'api/MaltidReports').subscribe(result => {
//            this.reports = result.json() as MaltidReport[];
//        }, error => console.error(error));
        this.updateReports();
    }

    ngOnChanges(changes: SimpleChanges) {
        console.log(changes);
        if (changes.reportdate) {
            this.reportdate = changes.reportdate.currentValue;
        } else if (changes.group) {
            this.group = changes.group.currentValue;
        }
        this.updateReports();
    }

    public updateReports(): void {
        console.log(this.group + ":" + this.reportdate);
        if (this.group && this.reportdate) {
            this.http.get(this.baseUrl + 'api/MaltidReports/' + this.group+ '/' + this.reportdate).subscribe(result => {
                this.reports = result.json() as MaltidReport[];
            }, error => console.error(error));
        }
    }

    public editMode(id: number, toggle: boolean): void {
        var result = this.reports.find(p => (p.rapport_ID == id))
        if (result) {
            console.log(toggle + ":" + result.editMode);
            result.editMode = (toggle ? !result.editMode : true);
        }
    }

    public new(): void {
        this.reports.push({
            rapport_ID: -1,
            portionstyp_ID: '',
            antal: 0,
            verksamhet_ID: this.group,
            rapport_Anvandare: '',
            rapport_Datum: new Date(this.reportdate),
            editMode: true
        } as MaltidReport);
    }

    public save(id: number): void {
        console.log(id);
        var reportIx = this.reports.findIndex(p => (p.rapport_ID == id))
        if (reportIx >= 0) {
            if (id >= 0) {
                this.http.put(this.baseUrl + 'api/MaltidReports/' + id, this.reports[reportIx]).subscribe(result => {
                    console.log("Report " + id + " updated ok.");
                    this.reports[reportIx].editMode = false;
                }, error => console.error(error));
            } else {
                this.http.post(this.baseUrl + 'api/MaltidReports', this.reports[reportIx]).subscribe(result => {
                    console.log(result.json());
                    this.reports[reportIx] = result.json() as MaltidReport;
                }, error => console.error(error));
            }
        }
    }

    public delete(id: number): void {
        console.log("Deleting: " + id);
        var reportIx = this.reports.findIndex(p => (p.rapport_ID == id))
        if (reportIx >= 0) {
            this.http.delete(this.baseUrl + 'api/MaltidReports/' + id).subscribe(result => {
                this.reports.splice(reportIx, 1);
            }, error => console.error(error))
        }
    }

    public cancel(id: number): void {
        var result = this.reports.find(p => (p.rapport_ID == id))
        if (result) {
            result.editMode = false;
        }
    }

    idTracker(id: number, value: any): number {
        return id;
    }

    public test2(): void {
        console.log(this.categories.getType('P-01'));
    }

    public reverse(): MaltidReport[] {
        var result: MaltidReport[] = [];
        if (this.reports) {
            result = this.reports.slice().reverse();
        }
        return result;
    }

    public log(msg: string): void {
        console.log(msg);
    }
}

interface MaltidReport {
    rapport_ID: number;
    portionstyp_ID: string;
    antal: number;
    verksamhet_ID: string;
    rapport_Anvandare: string;
    rapport_Datum: Date;
    editMode?: boolean;
}
