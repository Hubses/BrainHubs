import { InMemoryDbService } from 'angular-in-memory-web-api';
export class InMemoryDataService implements InMemoryDbService {
    createDb() {
        let news = [
            { id: 11, name: 'Mr. Nice', category: 'Спорт' },
            { id: 12, name: 'Narco', category: 'В мире' },
            { id: 13, name: 'Bombasto', category: 'Политика' },
            { id: 14, name: 'Celeritas', category: 'Общество' },
            { id: 15, name: 'Magneta', category: 'Общество' },
            { id: 16, name: 'RubberMan', category: 'Общество' },
            { id: 17, name: 'Dynama', category: 'Общество' },
            { id: 18, name: 'Dr IQ', category: 'Общество' },
            { id: 19, name: 'Magma', category: 'Общество' },
            { id: 20, name: 'Tornado', category: 'Общество' }
        ];
        return { news };
    }
}