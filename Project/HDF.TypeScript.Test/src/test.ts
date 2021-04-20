
interface Array<T> {
    FirstOrDefault(predicate?: (item: T) => boolean): T;
    Select<R>(func: (item: T) => R): R[];
    Where(func: (item: T) => boolean): T[];
    OrderBy(func: (item: T) => any): T[];
    OrderByDescending(func: (item: T) => any): T[];
    OrderByMany(func: [(item: T) => any]): T[];
    OrderByManyDescending(func: [(item: T) => any]): T[];
    Remove(item: T): boolean;
    Add(item: T): void;
    AddRange(items: T[]): void;
    RemoveRange(items: T[]): void;
}

if (!Array.prototype.FirstOrDefault) {
    Array.prototype.FirstOrDefault = function <T>(func?: (item: T) => boolean): T | null {
        if (func === undefined) {
            if (this.length > 0) return this[0]
            return null;
        }
        for (var i = 0; i < this.length; i++) {
            if (func(this[i]))
                return this[i];
        }
        return null;
    }
}
if (!Array.prototype.Where) {
    Array.prototype.Where = function <T>(func: (item: T) => boolean): T[] {
        let result: T[] = [];
        for (var i = 0; i < this.length; i++) {
            if (func(this[i]))
                result.push(this[i]);
        }
        return result;
    }
}
if (!Array.prototype.Select) {
    Array.prototype.Select = function <T, R>(func: (item: T) => R): R[] {
        let result: R[] = [];
        for (var i = 0; i < this.length; i++) {
            result.push(func(this[i]));
        }
        return result;
    }
}
if (!Array.prototype.Remove) {
    Array.prototype.Remove = function <T>(item: T): boolean {
        let index = this.indexOf(item);
        if (index >= 0) {
            this.splice(index, 1);
            return true;
        }
        return false;
    }
}
if (!Array.prototype.RemoveRange) {
    Array.prototype.RemoveRange = function <T>(items: T[]): void {
        for (var i = 0; i < items.length; i++) {
            this.Remove(items[i]);
        }
    }
}
if (!Array.prototype.Add) {
    Array.prototype.Add = function <T>(item: T): void {
        this.push(item);
    }
}
if (!Array.prototype.AddRange) {
    Array.prototype.AddRange = function <T>(items: T[]): void {
        for (var i = 0; i < items.length; i++) {
            this.push(items[i]);
        }
    }
}
if (!Array.prototype.OrderBy) {
    Array.prototype.OrderBy = function <T>(func: (item: T) => any) {
        let result: Array<any> = [];
        var compareFunction = (item1: T, item2: T): number => {
            if (func(item1) > func(item2)) return 1;
            if (func(item2) > func(item1)) return -1;
            return 0;
        }
        for (var i = 0; i < this.length; i++) {
            return this.sort(compareFunction);
        }
        return result;
    }
}
if (!Array.prototype.OrderByDescending) {
    Array.prototype.OrderByDescending = function (func: (item: any) => any) {
        let result: Array<any> = [];
        var compareFunction = (item1: any, item2: any): number => {
            if (func(item1) > func(item2)) return -1;
            if (func(item2) > func(item1)) return 1;
            return 0;
        }
        for (var i = 0; i < this.length; i++) {
            return this.sort(compareFunction);
        }
        return result;
    }
}
if (!Array.prototype.OrderByMany) {
    Array.prototype.OrderByMany = function (funcs: [(item: any) => any]) {
        let result: Array<any> = [];
        var compareFunction = (item1: any, item2: any): number => {
            for (var i = 0; i < funcs.length; i++) {
                let func = funcs[i];
                if (func(item1) > func(item2)) return 1;
                if (func(item2) > func(item1)) return -1;
            }
            return 0;
        }
        for (var i = 0; i < this.length; i++) {
            return this.sort(compareFunction);
        } return result;
    }
}
if (!Array.prototype.OrderByManyDescending) {
    Array.prototype.OrderByManyDescending = function (funcs: [(item: any) => any]) {
        let result: Array<any> = [];
        var compareFunction = (item1: any, item2: any): number => {
            for (var i = 0; i < funcs.length; i++) {
                let func = funcs[i];
                if (func(item1) > func(item2)) return -1;
                if (func(item2) > func(item1)) return 1;
            }
            return 0;
        }
        for (var i = 0; i < this.length; i++) {
            return this.sort(compareFunction);
        }
        return result;
    }
}






































