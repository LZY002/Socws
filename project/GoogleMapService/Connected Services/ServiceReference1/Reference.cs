﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace GoogleMapService.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Station", Namespace="http://schemas.datacontract.org/2004/07/VelbService.bussinessObjet")]
    [System.SerializableAttribute()]
    public partial class Station : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string addressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int available_bike_standsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int available_bikesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool bankingField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int bike_standsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool bonusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string contract_nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long last_updateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int numberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private GoogleMapService.ServiceReference1.Position positionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string statusField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string address {
            get {
                return this.addressField;
            }
            set {
                if ((object.ReferenceEquals(this.addressField, value) != true)) {
                    this.addressField = value;
                    this.RaisePropertyChanged("address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int available_bike_stands {
            get {
                return this.available_bike_standsField;
            }
            set {
                if ((this.available_bike_standsField.Equals(value) != true)) {
                    this.available_bike_standsField = value;
                    this.RaisePropertyChanged("available_bike_stands");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int available_bikes {
            get {
                return this.available_bikesField;
            }
            set {
                if ((this.available_bikesField.Equals(value) != true)) {
                    this.available_bikesField = value;
                    this.RaisePropertyChanged("available_bikes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool banking {
            get {
                return this.bankingField;
            }
            set {
                if ((this.bankingField.Equals(value) != true)) {
                    this.bankingField = value;
                    this.RaisePropertyChanged("banking");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int bike_stands {
            get {
                return this.bike_standsField;
            }
            set {
                if ((this.bike_standsField.Equals(value) != true)) {
                    this.bike_standsField = value;
                    this.RaisePropertyChanged("bike_stands");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool bonus {
            get {
                return this.bonusField;
            }
            set {
                if ((this.bonusField.Equals(value) != true)) {
                    this.bonusField = value;
                    this.RaisePropertyChanged("bonus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string contract_name {
            get {
                return this.contract_nameField;
            }
            set {
                if ((object.ReferenceEquals(this.contract_nameField, value) != true)) {
                    this.contract_nameField = value;
                    this.RaisePropertyChanged("contract_name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long last_update {
            get {
                return this.last_updateField;
            }
            set {
                if ((this.last_updateField.Equals(value) != true)) {
                    this.last_updateField = value;
                    this.RaisePropertyChanged("last_update");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int number {
            get {
                return this.numberField;
            }
            set {
                if ((this.numberField.Equals(value) != true)) {
                    this.numberField = value;
                    this.RaisePropertyChanged("number");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public GoogleMapService.ServiceReference1.Position position {
            get {
                return this.positionField;
            }
            set {
                if ((object.ReferenceEquals(this.positionField, value) != true)) {
                    this.positionField = value;
                    this.RaisePropertyChanged("position");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string status {
            get {
                return this.statusField;
            }
            set {
                if ((object.ReferenceEquals(this.statusField, value) != true)) {
                    this.statusField = value;
                    this.RaisePropertyChanged("status");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Position", Namespace="http://schemas.datacontract.org/2004/07/VelbService.bussinessObjet")]
    [System.SerializableAttribute()]
    public partial class Position : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string latField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string lngField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string lat {
            get {
                return this.latField;
            }
            set {
                if ((object.ReferenceEquals(this.latField, value) != true)) {
                    this.latField = value;
                    this.RaisePropertyChanged("lat");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string lng {
            get {
                return this.lngField;
            }
            set {
                if ((object.ReferenceEquals(this.lngField, value) != true)) {
                    this.lngField = value;
                    this.RaisePropertyChanged("lng");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IVelibService")]
    public interface IVelibService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibService/GetAllCities", ReplyAction="http://tempuri.org/IVelibService/GetAllCitiesResponse")]
        string GetAllCities();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibService/GetAllCities", ReplyAction="http://tempuri.org/IVelibService/GetAllCitiesResponse")]
        System.Threading.Tasks.Task<string> GetAllCitiesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibService/GetAllStationsOfCity", ReplyAction="http://tempuri.org/IVelibService/GetAllStationsOfCityResponse")]
        string GetAllStationsOfCity(string city_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibService/GetAllStationsOfCity", ReplyAction="http://tempuri.org/IVelibService/GetAllStationsOfCityResponse")]
        System.Threading.Tasks.Task<string> GetAllStationsOfCityAsync(string city_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibService/GetInfomationsOfStation", ReplyAction="http://tempuri.org/IVelibService/GetInfomationsOfStationResponse")]
        string GetInfomationsOfStation(string city_name, string station_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibService/GetInfomationsOfStation", ReplyAction="http://tempuri.org/IVelibService/GetInfomationsOfStationResponse")]
        System.Threading.Tasks.Task<string> GetInfomationsOfStationAsync(string city_name, string station_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibService/GetHelp", ReplyAction="http://tempuri.org/IVelibService/GetHelpResponse")]
        string GetHelp();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibService/GetHelp", ReplyAction="http://tempuri.org/IVelibService/GetHelpResponse")]
        System.Threading.Tasks.Task<string> GetHelpAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibService/GetStations", ReplyAction="http://tempuri.org/IVelibService/GetStationsResponse")]
        GoogleMapService.ServiceReference1.Station[] GetStations(string city);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibService/GetStations", ReplyAction="http://tempuri.org/IVelibService/GetStationsResponse")]
        System.Threading.Tasks.Task<GoogleMapService.ServiceReference1.Station[]> GetStationsAsync(string city);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IVelibServiceChannel : GoogleMapService.ServiceReference1.IVelibService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VelibServiceClient : System.ServiceModel.ClientBase<GoogleMapService.ServiceReference1.IVelibService>, GoogleMapService.ServiceReference1.IVelibService {
        
        public VelibServiceClient() {
        }
        
        public VelibServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public VelibServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VelibServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VelibServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetAllCities() {
            return base.Channel.GetAllCities();
        }
        
        public System.Threading.Tasks.Task<string> GetAllCitiesAsync() {
            return base.Channel.GetAllCitiesAsync();
        }
        
        public string GetAllStationsOfCity(string city_name) {
            return base.Channel.GetAllStationsOfCity(city_name);
        }
        
        public System.Threading.Tasks.Task<string> GetAllStationsOfCityAsync(string city_name) {
            return base.Channel.GetAllStationsOfCityAsync(city_name);
        }
        
        public string GetInfomationsOfStation(string city_name, string station_name) {
            return base.Channel.GetInfomationsOfStation(city_name, station_name);
        }
        
        public System.Threading.Tasks.Task<string> GetInfomationsOfStationAsync(string city_name, string station_name) {
            return base.Channel.GetInfomationsOfStationAsync(city_name, station_name);
        }
        
        public string GetHelp() {
            return base.Channel.GetHelp();
        }
        
        public System.Threading.Tasks.Task<string> GetHelpAsync() {
            return base.Channel.GetHelpAsync();
        }
        
        public GoogleMapService.ServiceReference1.Station[] GetStations(string city) {
            return base.Channel.GetStations(city);
        }
        
        public System.Threading.Tasks.Task<GoogleMapService.ServiceReference1.Station[]> GetStationsAsync(string city) {
            return base.Channel.GetStationsAsync(city);
        }
    }
}
