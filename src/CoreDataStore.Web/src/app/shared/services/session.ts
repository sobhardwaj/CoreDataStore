export class SessionService {

  get(key: string) {
    let record: any;
    record = JSON.parse(sessionStorage.getItem(key));
    if (!record) {
      return null;
    }
    return new Date().getTime() < record.timestamp && JSON.parse(record.value);
  };

  set(key: string, val: any, time ? : number) {
    let expire: number, record: any;
    expire = time ? (time * 60 * 1000) : 864000;
    record = {
      value: JSON.stringify(val),
      timestamp: new Date().getTime() + expire
    };
    sessionStorage.setItem(key, JSON.stringify(record));
    return val;
  };

  unset(key: string) {
    return sessionStorage.removeItem(key);
  }
};
