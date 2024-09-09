using Microsoft.VisualBasic;
using Repositories;

namespace Services;

public abstract class IBaseService {
    protected readonly StoreDBContext databaseContext;
    public IBaseService () {
        this.databaseContext = new StoreDBContext();
    }
}