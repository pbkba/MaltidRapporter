import { Component, Inject, Input } from '@angular/core';
import { Http } from '@angular/http';
import { CookieService } from 'angular2-cookie/core';
import { CategoriesComponent } from '../categories/categories.component';

@Component({
    selector: 'groups',
    templateUrl: './groups.component.html',
    providers: [CookieService]
})

export class GroupsComponent {
    public groups: MaltidGroup[];
    public selectedGroup: string;

    @Input() categories: CategoriesComponent;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string, private cookieService: CookieService) {
        http.get(baseUrl + 'api/MaltidVerksamhet').subscribe(result => {
            this.groups = result.json() as MaltidGroup[];
        }, error => console.error(error));
    }

    ngOnInit(): void {
        this.selectedGroup = this.cookieService.get("KBA-MALTID-GRUPP");
    }

    public getGroups(category: string): MaltidGroup[] {
        var result: MaltidGroup[] = [];
        if (this.groups) {
            result = this.groups.reduce(
                function (acc: MaltidGroup[], cur: MaltidGroup) {
                    if (cur.forvaltning == category) {
                        acc.push(cur);
                    }
                    return acc;
                }, []);
        }
        return result;
    }

    public test3(): void {
        console.log(this.cookieService.get("KBA-MALTID-KATEGORI") + "/" + this.cookieService.get("KBA-MALTID-GRUPP") );
    }

    public updateGroup(): void {
        var expires = new Date();
        expires.setDate(expires.getDate() + 60);
        this.cookieService.put("KBA-MALTID-GRUPP", this.selectedGroup, { "expires": expires });
    }
}

interface MaltidGroup {
    ID: number;
    verksamhet_ID: string;
    forvaltning: string;
    kundkod: string;
    gruppnamn: string;
    namn: string;
    ansvar: number;
    verksamhet: number;
    aktivitet: number;
    motpart: number;
    kokAnsvar: number;
    tKKok: number;
}
