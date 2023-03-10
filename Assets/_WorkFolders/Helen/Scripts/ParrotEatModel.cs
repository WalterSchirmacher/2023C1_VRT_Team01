using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;
using UnityEngine.XR.Interaction.Toolkit;


[RealtimeModel]
public partial class ParrotEatModel 
{
    [RealtimeProperty(2, true, true)]
    private bool _isObjectInSocket;

}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class ParrotEatModel : RealtimeModel {
    public bool isObjectInSocket {
        get {
            return _isObjectInSocketProperty.value;
        }
        set {
            if (_isObjectInSocketProperty.value == value) return;
            _isObjectInSocketProperty.value = value;
            InvalidateReliableLength();
            FireIsObjectInSocketDidChange(value);
        }
    }
    
    public delegate void PropertyChangedHandler<in T>(ParrotEatModel model, T value);
    public event PropertyChangedHandler<bool> isObjectInSocketDidChange;
    
    public enum PropertyID : uint {
        IsObjectInSocket = 2,
    }
    
    #region Properties
    
    private ReliableProperty<bool> _isObjectInSocketProperty;
    
    #endregion
    
    public ParrotEatModel() : base(null) {
        _isObjectInSocketProperty = new ReliableProperty<bool>(2, _isObjectInSocket);
    }
    
    protected override void OnParentReplaced(RealtimeModel previousParent, RealtimeModel currentParent) {
        _isObjectInSocketProperty.UnsubscribeCallback();
    }
    
    private void FireIsObjectInSocketDidChange(bool value) {
        try {
            isObjectInSocketDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    protected override int WriteLength(StreamContext context) {
        var length = 0;
        length += _isObjectInSocketProperty.WriteLength(context);
        return length;
    }
    
    protected override void Write(WriteStream stream, StreamContext context) {
        var writes = false;
        writes |= _isObjectInSocketProperty.Write(stream, context);
        if (writes) InvalidateContextLength(context);
    }
    
    protected override void Read(ReadStream stream, StreamContext context) {
        var anyPropertiesChanged = false;
        while (stream.ReadNextPropertyID(out uint propertyID)) {
            var changed = false;
            switch (propertyID) {
                case (uint) PropertyID.IsObjectInSocket: {
                    changed = _isObjectInSocketProperty.Read(stream, context);
                    if (changed) FireIsObjectInSocketDidChange(isObjectInSocket);
                    break;
                }
                default: {
                    stream.SkipProperty();
                    break;
                }
            }
            anyPropertiesChanged |= changed;
        }
        if (anyPropertiesChanged) {
            UpdateBackingFields();
        }
    }
    
    private void UpdateBackingFields() {
        _isObjectInSocket = isObjectInSocket;
    }
    
}
/* ----- End Normal Autogenerated Code ----- */
